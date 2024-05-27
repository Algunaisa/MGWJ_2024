using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    private bool backpackopen = false;
    public GameObject bagContainer;
    void Start()
    {
        bagContainer.SetActive(backpackopen);
    }

    void Update()
    {
        if (Input.GetButtonDown("Backpack")){
            backpackopen = !backpackopen;
            bagContainer.SetActive(backpackopen);
        }
    }
}
