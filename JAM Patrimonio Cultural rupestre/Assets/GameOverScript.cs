using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //blic HealthBarController HealthBarController;
    public void Setup()
    {
        gameObject.SetActive(true);
        //althBarController.gameObject.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Rupestralia");
    }
}
