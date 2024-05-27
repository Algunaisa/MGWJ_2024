using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item itemData;

    void OnTriggerEnter2D(Collider2D other)
    {
        // FIXME cada collider agrega un item, antes de que se destruya. 
        // Diferenciar colliders con tagnames?
        Debug.Log(itemData.description);
        BagManager.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
