using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration;

    public float groundSpeed;
    public float jumpSpeed;

    [Range(0f, 1f)]
    public float groundDecay;
    public Rigidbody2D body;

    float xInput;
    float yInput;

    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    public bool grounded;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleJump();


        //Vector2 direction = new Vector2(xInput, 0).normalized;
        //body.velocity = direction * speed;
    }

    void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        MoveWithInput();
        animator.SetFloat("xVelocity",Math.Abs(body.velocity.x));
        animator.SetFloat("yVelocity", body.velocity.y);
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        //grounded = false;
        animator.SetBool("isJumping", !grounded);
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void MoveWithInput()
    {
        Debug.Log("MoveWithInput");
        if (Mathf.Abs(xInput) > 0)
        {
            //float increment = xInput * acceleration;
            //float newSpeed = Mathf.Clamp(body.velocity.x + increment, -groundSpeed, groundSpeed);
            //body.velocity = new Vector2(newSpeed, body.velocity.y);

            body.velocity = new Vector2(xInput * groundSpeed, body.velocity.y);//.normalized;

            float direction = Mathf.Sign(xInput);// + / -
            transform.localScale = new Vector3(direction, 1, 1);
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }

    void HandleJump()
    {
        //if (Mathf.Abs(yInput) > 0)
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);//.normalized;
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);//.normalized;
        }
    }
    void ApplyFriction()
    {
        //if (grounded && xInput == 0 && yInput == 0)
        if (grounded && xInput == 0 && body.velocity.y <= 0)
        {
            body.velocity *= groundDecay;
        }

    }
}
