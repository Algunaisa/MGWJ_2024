using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
// FIXME varios jabalies sobre una linea no saben que hacer XD
public class JabaliMovement : MonoBehaviour
{
    public float groundSpeed;
    public float hornDamage;
    public Rigidbody2D body;
    // public  Action<Vector2> OnWalkTrigger;
    public  Action OnWalkTrigger;

    private Vector2 direction = Vector2.right;
    // private List<float> limits = new List<float>();
    private IEnumerator coroutine;
    private bool grounded;
    private bool eating = false;

    void Start()
    {
        OnWalkTrigger = ChangeDirection2;
        float waitTime = UnityEngine.Random.Range(1,3);
        coroutine = EatSomething(waitTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator EatSomething(float waitTime){
        while(true){
            yield return new WaitForSeconds(waitTime);
            // Debug.Log("Eating something");
            eating = !eating;
        }
    }

    public void ChangeDirection2(){
        if (direction == Vector2.right) direction = Vector2.left;
        else direction = Vector2.right;

        // FIXME el jabali quiere caerse estando sobre el suelo, tiene miedo y se da la vuelta xD
        // Porque se tambalea, algo le pasa con el tilemap?
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
        grounded = true;
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("JUGADOr metiche");
            other.gameObject.GetComponent<PlayerHealth>().OnPlayerHealthChange(hornDamage);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }
    void MoveWithAI(){
        if (grounded){
            if (eating) body.velocity = Vector2.zero;
            else body.velocity = direction * groundSpeed;
        }
    }
}
