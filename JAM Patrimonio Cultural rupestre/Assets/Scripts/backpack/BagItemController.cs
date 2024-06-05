using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItemController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealth playerHealth;
    private BagController bagController;
    private Button button;
    private Item itemData;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickItem);
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        bagController = GameObject.Find("CanvasBag").GetComponent<BagController>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnClickItem()
    {
        Debug.Log(itemData.description);
        Debug.Log(itemData.value);
        if (itemData.itemType == Item.ItemType.Consumible)
        {
            playerHealth.OnPlayerHealthChange(itemData.value);
            BagManager.Instance.RemoveItem(itemData);
        }

        if (itemData.itemType == Item.ItemType.Rupestre)
        {
            // Debug.Log("Mostrando Historia!");
            if (bagController != null)
            {
                bagController.onDisplayHistory.Invoke(itemData.sprite, itemData.description);
            }
        }
    }
    public void setItem(Item item)
    {
        itemData = item;
    }
}

