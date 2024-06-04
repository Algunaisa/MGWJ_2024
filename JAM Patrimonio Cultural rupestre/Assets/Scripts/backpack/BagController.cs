using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    private bool backpackopen = false;
    public GameObject bagContainer;
    private GameObject panelHistory;
    public Action<Sprite, string> onDisplayHistory;
    void Start()
    {
        bagContainer.SetActive(backpackopen);
        panelHistory = transform.Find("PanelHistory").gameObject;
        onDisplayHistory = OnDisplayHistory;
    }

    void Update()
    {
        if (Input.GetButtonDown("Backpack"))
        {
            backpackopen = !backpackopen;
            bagContainer.SetActive(backpackopen);
        }
    }
    void OnDisplayHistory(Sprite sprite, string texto)
    {
        if (panelHistory != null)
        {
            panelHistory.SetActive(true);
            panelHistory.GetComponent<PanelHistory>().SetImage(sprite);
            panelHistory.GetComponent<PanelHistory>().SetText(texto);
        }
        else Debug.Log("PANELHISTORY NULL");

    }
}
