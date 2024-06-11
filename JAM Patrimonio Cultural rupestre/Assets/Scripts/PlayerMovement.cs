using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum PlayerState { Idle, Running, Airborne }
    public float acceleration;

    public float groundSpeed;
    public float jumpSpeed;

    [Range(0f, 1f)]
    public float groundDecay;
    public Rigidbody2D body;

    float xInput;
    float yInput;

    public BoxCollider2D colliderCheck;
    public LayerMask groundMask;

    public bool grounded;

    public Animator animator;

    public float healt;
    public float healtMAX;

    [Header("Escalar")]
    [SerializeField] private float velocidadEscalar;
    //public BoxCollider2D climbCheck;
    private float gravedadInicial;
    private bool escalando;

    // Start is called before the first frame update
    private void Awake()
    {
        healtMAX = 1000;
    }
    void Start()
    {
        //body = GetComponent<Rigidbody2D>();
        gravedadInicial = body.gravityScale; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        HandleJump();

        checkClimb();
        //Vector2 direction = new Vector2(xInput, 0).normalized;
        //body.velocity = direction * speed;
    }

    void FixedUpdate()
    {
        CheckGround();
        //HandleJump();
        HandleXMovement();
        ApplyFriction();

        animator.SetFloat("xVelocity",Math.Abs(body.velocity.x));
        animator.SetFloat("yVelocity", body.velocity.y);
    }

    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }
    void HandleXMovement()
    {
        Debug.Log("MoveWithInput");
        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.velocity.x + increment, -groundSpeed, groundSpeed);
            body.velocity = new Vector2(newSpeed, body.velocity.y);

            //body.velocity = new Vector2(xInput * groundSpeed, body.velocity.y);//.normalized;

            FaceInput();
            
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }

    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);// + / -
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void HandleJump()
    {
        //if (Mathf.Abs(yInput) > 0)
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //body.velocity = new Vector2(body.velocity.x, yInput * jumpSpeed);//.normalized;
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);//.normalized;
            //animator.SetBool("isJumping", !grounded);
        }
    }

    void CheckGround()
    { 
        grounded = Physics2D.OverlapAreaAll(colliderCheck.bounds.min, colliderCheck.bounds.max, groundMask).Length > 0;
        //grounded = false;
        animator.SetBool("isJumping", !grounded);
    }
    void ApplyFriction()
    {
        //if (grounded && xInput == 0 && yInput == 0)
        if (grounded && xInput == 0 && body.velocity.y <= 0)
        {
            body.velocity *= groundDecay;
        }

    }

    void checkClimb()
    {
        if((yInput != 0 || escalando) && (colliderCheck.IsTouchingLayers(LayerMask.GetMask("Escaleras"))))
        {
            Vector2 velocidadSubida = new Vector2(body.velocity.x, yInput * velocidadEscalar);
            body.velocity = velocidadSubida;
            //Debug.Log("Check Climb " + velocidadSubida);
            body.gravityScale = 0;
            escalando = true;
        }
        else
        {
            //Debug.Log("yInput: " + yInput);
            body.gravityScale = gravedadInicial;
            escalando = false;
        }

        if(grounded)
        {
            escalando = false;
        }
    }

    /*HEALT*/
    private void startHealt()
    {
        healt = healtMAX;
        //Debug.Log("1OXY " + oxygen);
        //barOxyController.InicializarBarraDeVida(healt);
    }
    /*
    public void repair()
    {
        Debug.Log("Repair ship mass: " + mass);
        if ((mass - 1) >= 0 && mass < massMAX) //()
        {
            //[0] -> [3]
            shields[mass - 1].gameObject.SetActive(true);
            Debug.Log(shields[mass - 1].gameObject.name);
            mass++;
        }
    }
    */
}
