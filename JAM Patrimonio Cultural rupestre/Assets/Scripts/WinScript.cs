using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
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
