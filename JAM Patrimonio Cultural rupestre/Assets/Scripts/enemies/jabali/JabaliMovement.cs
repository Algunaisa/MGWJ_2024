using System.Collections;
using UnityEngine;
using System;
// FIXME varios jabalies sobre una linea no saben que hacer XD
public class JabaliMovement : MonoBehaviour
{
    public float groundSpeed = 2;
    public float atackSpeed = 5f;
    public float searchDistance = 3;
    public float hornDamage;
    public Rigidbody2D body;
    private Animator animator;
    // public  Action<Vector2> OnWalkTrigger;
    public Action OnWalkTrigger;
    public Action<bool> OnGroundTrigger;
    [SerializeField] private Transform eyes;

    private Vector3 direction = Vector3.right;
    private IEnumerator coroutine;
    private IEnumerator atackCoroutine;
    private IEnumerator eatCoroutine;
    private bool grounded;
    private bool relax = false;
    private bool eating = false;
    private bool isSearching = true;
    const string JABALI_IDLE = "jabali_idle";
    const string JABALI_WALK = "jabali_walk";
    const string JABALI_ATACK = "jabali_atack";
    const string JABALI_EAT = "jabali_eat";
    private string currentState = JABALI_IDLE;
    private float relaxTime = -1;
    [SerializeField] private float eatTime = 4f;


    void Start()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        OnWalkTrigger = ChangeDirection2;
        OnGroundTrigger = OnGround;
        coroutine = GoToWalk();
        atackCoroutine = GoToAtack();
        eatCoroutine = EatTime();
        StartCoroutine(coroutine);
        StartCoroutine(atackCoroutine);
        StartCoroutine(eatCoroutine);
        animator = GetComponent<Animator>();
    }

    private IEnumerator EatTime()
    {
        while (true)
        {
            if (!eating) yield return null;
            yield return new WaitForSeconds(eatTime);
            eating = false;
        }
    }

    private IEnumerator GoToWalk()
    {
        while (true)
        {
            if (eating) yield return null;
            if (relax)
            {
                yield return new WaitForSeconds(relaxTime);
                relax = false;
            }
            else
            {
                yield return new WaitForSeconds(
                    UnityEngine.Random.Range(3, 9)
                );
                relax = true;
            }
        }
    }
    private IEnumerator GoToAtack()
    {
        while (true)
        {
            if (eating) yield return null;
            if (!isSearching)
            {
                yield return new WaitForSeconds(2f);
                isSearching = true;
            }
            yield return null;
        }
    }
    private void OnGround(bool ground)
    {
        grounded = ground;
    }

    public void ChangeDirection2()
    {
        if (direction == Vector3.right) direction = Vector3.left;
        else direction = Vector3.right;

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
        SearchEnemy();
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
                ChangeAnimationState(JABALI_EAT);
            }
            else if (isSearching)
            {
                if (relax)
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
            else
            {
                ChangeAnimationState(JABALI_ATACK);
                body.velocity = direction * atackSpeed;
            }
        }
    }
    void SearchEnemy()
    {

        var finPos = eyes.position + searchDistance * direction;
        if (!isSearching)
        {
            Debug.DrawLine(eyes.position, finPos, Color.red);
            return;
        }
        else Debug.DrawLine(eyes.position, finPos, Color.white);

        RaycastHit2D hit = Physics2D.Linecast(eyes.position, finPos, LayerMask.GetMask("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                isSearching = false;
                Debug.Log("RAYOS");
            }
        }
    }
    void ChangeAnimationState(string newstate)
    {
        if (currentState == newstate) return;

        if (relaxTime < 0 && newstate == JABALI_WALK)
        {
            relaxTime = animator.GetCurrentAnimatorStateInfo(0).length;
        }
        animator.Play(newstate);
        currentState = newstate;
    }
    public void FromAnyStateToEat()
    {
        eating = true;
    }
}
