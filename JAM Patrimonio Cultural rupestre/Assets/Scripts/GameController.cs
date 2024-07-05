using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int countRestaurado;
    public WinScript winScript;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        countRestaurado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countRestaurado == 3)
        {
            winScript.Setup();
            playerMovement.playerOff();
            Debug.Log("WIN!!!");
            countRestaurado = 4;
        }
    }
}
