using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void ChangeMaxHealth(float maxHealth)
    {
        Debug.Log("slider " + slider.name);
        slider.maxValue = maxHealth;
    }
    public void ChangeActualHealth(float health)
    {
        slider.value = health;
    }
    // Update is called once per frame
    public void startHealthBar(float healt)
    {
        Debug.Log("slider " + slider.name);
        ChangeMaxHealth(healt);
        ChangeActualHealth(healt);
    }
}
