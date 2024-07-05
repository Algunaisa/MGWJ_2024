using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PetrograbadoItem : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private SpriteRenderer hoverSprite;
    [SerializeField] private MiniGameManager miniGameManager;
    [SerializeField] private MiniGameMessage miniGameMessage;
    [SerializeField] private int nTries = 5;
    [SerializeField] private float launchMiniGameTime = 2f;
    private Coroutine coroutineColor;

    public hoverGraffitiController hoverGraffitiController;
    //public int countRestaurado;
    public GameController gameController;

    private Color color1 = new Color(0.5225741f, 0.6226415f, 0, 1);
    private Color color2 = new Color(0.7531301f, 0.8962264f, 0, 1);
    private bool petrograbadoUnlocked = false;

    void Start()
    {
        hoverSprite.color = color2;
        hoverGraffitiController.gameObject.SetActive(true);
        coroutineColor = StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            hoverSprite.color = color1;
            yield return new WaitForSeconds(0.5f);
            hoverSprite.color = color2;
            yield return new WaitForSeconds(0.8f);
        }
    }
    private IEnumerator MiniGameStatus()
    {
        miniGameManager.nTries = nTries;
        yield return miniGameMessage.ShowTemporalMessage(
            "Ready...",
            0.7f * launchMiniGameTime);
        yield return miniGameManager.LaunchMiniGame(launchMiniGameTime);
        if (miniGameManager.IsWinner())
        {
            Debug.Log("PETRO unlocked");
            petrograbadoUnlocked = true;
            StopCoroutine(coroutineColor);
            hoverSprite.color = Color.green;

            hoverGraffitiController.gameObject.SetActive(false);
            gameController.countRestaurado++;

            yield return miniGameMessage.ShowTemporalMessage(
            "Petrograbado restaurado", 2.5f);
        }
        else
        {
            Debug.Log("Wins " + miniGameManager.wins + " Try again");
            yield return miniGameMessage.ShowTemporalMessage(
               "Be serious try again", 2.5f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!petrograbadoUnlocked)
        {
            Debug.Log("Start minigame");
            StartCoroutine(MiniGameStatus());
        }
        else
        {
            StartCoroutine(miniGameMessage.ShowTemporalMessage(
                "Petrograbado restaurado",
                2f));
            Debug.Log("Petrograbado Unlocked");
        }
    }
}
