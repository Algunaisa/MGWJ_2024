using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool inCave;
    public float health;
    public float maxHealth;
    public int healthDownHeat;
    public int healthDownDamage;

    public HealthBarController healthBarController;
    private void Awake()
    {
        //New Game
        Debug.Log("Awake");

        maxHealth = 1000;
        healthDownHeat = 5;
        healthDownDamage = 15;
        inCave = true;
    }
    void Start()
    {
        health = maxHealth;
        healthBarController.startHealthBar(health);
    }
    private void Update()
    {
        healthCheck();
    }
    private void healthCheck()
    {
        //Lose Health
        if (!inCave)
        {
            health -= healthDownHeat * Time.deltaTime;

        }
        if (health <= 0)
        {
            Debug.Log("Game Over, No Health");
            Start();
        }

        healthBarController.ChangeActualHealth(health);
    }

}
