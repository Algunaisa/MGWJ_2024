using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Serpiente_Script : MonoBehaviour
{
    public GameObject PlayerMovement;
    public float JumpForce; // Fuerza del salto
    public float detectionRange; // Rango de detección  
    public float Snake_Attack;
    private Rigidbody2D rb;
    private float LastJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       

        Vector3 direction = PlayerMovement.transform.position - transform.position;//calcula la direccion de donde esta el jugador izq y der
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
        float distance = Mathf.Abs(PlayerMovement.transform.position.x - transform.position.x); //Obtiene la distancia entre el jugador y el enemigo
        if (distance <= detectionRange && Time.time>LastJump + 2.5f)
        {
            JumpTowardsPlayer(direction);
            LastJump = Time.time;
        }
    }
    private void JumpTowardsPlayer(Vector3 direction)
    {
        direction.Normalize(); // Normaliza la dirección para que tenga una longitud de 1
        rb.AddForce(new Vector2(direction.x, 1) * JumpForce, ForceMode2D.Impulse); // Aplica una fuerza de salto en la dirección del jugador
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().OnPlayerHealthChange(Snake_Attack);
        }
    }
}
