using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelHistory : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    private Button close;
    void Start()
    {
        // image = transform.Find("ArtImage").GetComponent<Image>();
        // text = transform.Find("ArtHistory").GetComponent<TextMeshProUGUI>();
        close = GetComponentInChildren<Button>();
        close.onClick.AddListener(() => gameObject.SetActive(false));
    }
    void Update()
    {
    }
    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void SetText(string texto)
    {
        text.text = texto;
    }
}
