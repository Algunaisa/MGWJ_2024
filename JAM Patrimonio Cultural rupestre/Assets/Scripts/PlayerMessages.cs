using System.Collections;
using UnityEngine;

public class PlayerMessages : MonoBehaviour
{
    [SerializeField] private MiniGameMessage miniGameMessage;
    void Start()
    {
        if (miniGameMessage == null) Debug.Log("Canvas message not found");
        else Debug.Log("Canvas message found");
        StartCoroutine(Tutorial());
    }

    private IEnumerator Tutorial()
    {
        yield return miniGameMessage.ShowMessage("Moverse: WASD", 2f);
        yield return miniGameMessage.ShowMessage("Saltar: Space bar", 2f);
        yield return miniGameMessage.ShowMessage("Alimentar jabali: P", 2f);
        yield return miniGameMessage.ShowMessage("Mochila: B", 2f);
        yield return miniGameMessage.ShowMessage("Botones del MiniJuego: Y,U,I", 3f);   
        miniGameMessage.DisableMessages();
    }
}