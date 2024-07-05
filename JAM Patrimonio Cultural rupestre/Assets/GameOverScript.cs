using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    //blic HealthBarController HealthBarController;
    public void Setup()
    {
        gameObject.SetActive(true);
        playerMovement.playerOff();
        //althBarController.gameObject.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Rupestralia");
    }
}
