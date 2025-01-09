using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{
    Dictionary<int, ItemDetails> itemDetailsDictionary;

    [SerializeField] SO_ItemList itemList = null;

    protected override void Awake(){
        base.Awake();
        //  사전생성
        CreateItemDetailsDictionary();
    }

    void CreateItemDetailsDictionary(){
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach(ItemDetails itemDetails in itemList.itemDetails){
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    public ItemDetails GetItemDetails(int itemCode){
        ItemDetails itemDetails;

        if(itemDetailsDictionary.TryGetValue(itemCode, out itemDetails)){
            return itemDetails;
        }
        else{
            return null;
        }
    }
}
