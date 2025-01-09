using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        Item item = other.GetComponent<Item>();
        if(item !=null){
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);

            // item Description을 출력하기
            Debug.Log(itemDetails.itemDescription);
        }
    }
}
