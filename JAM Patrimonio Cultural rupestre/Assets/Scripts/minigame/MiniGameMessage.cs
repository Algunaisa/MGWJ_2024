using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameMessage : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    private TextMeshProUGUI text;
    void Awake()
    {
        text = messagePanel.GetComponent<TextMeshProUGUI>();
        if (text) Debug.Log("TextMessage object Loaded");
        else Debug.Log("TextMessage object not found");
    }
    void Start()
    {
        // StartCoroutine(ShowMessage("Ready...", 2f));
    }
    public IEnumerator ShowTemporalMessage(string message, float time)
    {

        text.text = message;
        messagePanel.SetActive(true);
        yield return new WaitForSeconds(time);
        messagePanel.SetActive(false);
    }

    public IEnumerator ShowMessage(string message, float time)
    {
        messagePanel.SetActive(true);
        text.text = message;
        yield return new WaitForSeconds(time);
    }
    public void DisableMessages()
    {
        messagePanel.SetActive(false);
    }

}
