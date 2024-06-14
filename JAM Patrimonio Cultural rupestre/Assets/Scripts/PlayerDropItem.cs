using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DropBagItem();
        }
    }
    private void DropBagItem(){
        Vector3 pos = transform.position;
        PlayerMovement player = GetComponent<PlayerMovement>();
        pos = pos + 1.5f * player.faceDirection;
        GameObject itemToDrop = BagManager.Instance.DroppableItemBag(pos);
        ItemController itemCon = itemToDrop.GetComponent<ItemController>();
        itemCon.dropdown = true;
        if(itemToDrop){
            Debug.Log("Item Consumible Dropped");
        }else{
            Debug.Log("NO hay consumibles");
        }
    }
}
