using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BagManager Instance;
    public List<Item> items;
    public Transform bagContainer;
    [SerializeField] private GameObject bagItem;
    [SerializeField] private GameObject itemTemplate;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        if (gameObject.activeSelf) ListItems();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (gameObject.activeSelf) ListItems();
    }

    public GameObject DroppableItemBag(Vector3 transform)
    {
        foreach (Item item in items)
        {
            if (item.droppable)
            {
                GameObject itemDrop = Instantiate(itemTemplate, transform, Quaternion.identity);
                ItemController contr = itemDrop.GetComponent<ItemController>();
                contr.ChangeItem(item);
                RemoveItem(item);
                return itemDrop;
            }
        }
        return null;
    }

    public void ListItems()
    {
        foreach (Transform item in bagContainer)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(bagItem, bagContainer);
            obj.GetComponent<Image>().sprite = item.sprite;
            obj.GetComponent<BagItemController>().setItem(item);
        }
    }
}
