using System.Collections;
using UnityEngine;
using System;
// FIXME varios jabalies sobre una linea no saben que hacer XD
public class JabaliMovement : MonoBehaviour
{
    public float groundSpeed;
    public float hornDamage;
    public Rigidbody2D body;
    private Animator animator;
    // public  Action<Vector2> OnWalkTrigger;
    public Action OnWalkTrigger;
    public Action<bool> OnGroundTrigger;

    private Vector2 direction = Vector2.right;
    private IEnumerator coroutine;
    private bool grounded;
    private bool eating = false;
    const string JABALI_IDLE = "jabali_idle";
    const string JABALI_WALK = "jabali_walk";
    private string currentState = JABALI_IDLE;
    private float eatTime = -1;


    void Start()
    {
        OnWalkTrigger = ChangeDirection2;
        OnGroundTrigger = OnGround;
        coroutine = GoToWalk();
        StartCoroutine(coroutine);
        animator = GetComponent<Animator>();
    }

    private IEnumerator GoToWalk()
    {
        while (true)
        {
            if (eating)
            {
                yield return new WaitForSeconds(eatTime);
                eating = false;
            }
            else
            {
                yield return new WaitForSeconds(
                    UnityEngine.Random.Range(3, 9)
                );
                eating = true;
            }
        }
    }
    private void OnGround(bool ground)
    {
        grounded = ground;
    }

    public void ChangeDirection2()
    {
        if (direction == Vector2.right) direction = Vector2.left;
        else direction = Vector2.right;

        // FIXME el jabali quiere caerse estando sobre el suelo, tiene miedo y se da la vuelta xD
        Vector2 locesc = transform.localScale;
        locesc.x *= -1;
        transform.localScale = locesc;
        // Debug.Log(direction);
    }

    // private void ChangeDirection(Vector2 dir){
    //     direction = dir;
    //     Debug.Log(direction);
    //     if (limits.Count<2) limits.Add(transform.position.x);
    //     else Debug.Log(((limits[0] + limits[1])/2).ToString());
    // }

    void Update()
    {
    }
    void FixedUpdate()
    {
        MoveWithAI();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("JUGADOr metiche");
            other.gameObject.GetComponent<PlayerHealth>().OnPlayerHealthChange(hornDamage);
        }
    }
    void MoveWithAI()
    {
        if (grounded)
        {
            if (eating)
            {
                body.velocity = Vector2.zero;
                ChangeAnimationState(JABALI_IDLE);
            }
            else
            {
                ChangeAnimationState(JABALI_WALK);
                body.velocity = direction * groundSpeed;
            }
        }
    }

    void ChangeAnimationState(string newstate)
    {
        if (currentState == newstate) return;

        if (eatTime < 0 && newstate == JABALI_WALK)
        {
            eatTime = animator.GetCurrentAnimatorStateInfo(0).length;
        }
        animator.Play(newstate);
        currentState = newstate;
    }
}
