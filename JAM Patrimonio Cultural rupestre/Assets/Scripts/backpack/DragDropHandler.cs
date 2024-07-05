using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private BagItemController bagItemController;
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    void Awake()
    {
        bagItemController = GetComponent<BagItemController>();
        rectTransform = GetComponent<RectTransform>();
        // TODO no existe un Canvas para BagContainer, implementar con offset/pivot/position?
        canvas = GameObject.Find("BagContainer").GetComponent<Canvas>();
        // canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            Debug.Log("Canvas encontrado");
            Debug.Log("Canvas NO encontrado");
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log("Hola " + pointerEventData.position);
        if (bagItemController != null)
        {
            Debug.Log(bagItemController.ItemType);
        }
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log("adios" + pointerEventData.position);
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        rectTransform.anchoredPosition = pointerEventData.position;
    }
}
