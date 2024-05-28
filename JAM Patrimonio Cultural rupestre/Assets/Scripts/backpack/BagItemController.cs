using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItemController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealth playerHealth;
    private Button button;
    private Item itemData;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickItem);
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnClickItem(){
        Debug.Log(itemData.description);
        Debug.Log(itemData.value);
        playerHealth.OnPlayerHealthChange(itemData.value);
        BagManager.Instance.RemoveItem(itemData);
    }
    public void setItem(Item item){
        itemData = item;
    }
}

