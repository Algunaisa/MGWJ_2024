using UnityEngine;
using UnityEngine.EventSystems;

public class OptionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject background;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        background.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        background.SetActive(false);
    }
}
