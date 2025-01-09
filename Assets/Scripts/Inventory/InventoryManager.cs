using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{
    Dictionary<int, ItemDetails> itemDetailsDictionary;
    public List<InventoryItem>[] inventoryListArray;  // 인벤토리아이템을 갖고 있는 리스트에 대한 어레이
    [HideInInspector] public int[] inventoryListCapacityIntArray; // the index of the array is the inventory list (from the InventoryLocation enum), and the value is the capacity of that inventory list

    [SerializeField] SO_ItemList itemList = null;

    protected override void Awake(){
        base.Awake();

        // Inventory Lists 생성
        CreateInventoryLists();
        //  사전생성
        CreateItemDetailsDictionary();
    }

    void CreateInventoryLists(){
        inventoryListArray = new List<InventoryItem>[(int)InventoryLocation.count];

        for(int i=0; i< (int)InventoryLocation.count; i++){
            inventoryListArray[i] = new List<InventoryItem>();
        }

        // inventory list capacity array를 초기화
        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count]; //InventoryLocation.count는 2이다.

        // player inventory list capacity 초기화
        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerInitialInventoryCapacity;
    }

    public void AddItem(InventoryLocation inventoryLocation, Item item, GameObject gameObjectToDelete){
        AddItem(inventoryLocation, item);

        Destroy(gameObjectToDelete);
    }

    public void AddItem(InventoryLocation inventoryLocation, Item item){
        int itemCode = item.ItemCode;
        List<InventoryItem> inventoryList = inventoryListArray[(int)inventoryLocation];//입력받은 inventoryLocation 인덱스번호

        // inventory가 이미 해당 item을 갖고 있는지 체크
        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if(itemPosition != -1){ //찾지 못했을 경우
            AddItemPosition(inventoryList, itemCode, itemPosition);
        } 
        else{
            AddItemPosition(inventoryList, itemCode);
        }

        // Send event that inventory has been updated
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryListArray[(int)inventoryLocation]);

    }

    public int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode){
        List<InventoryItem> inventoryList = inventoryListArray[(int)inventoryLocation];

        for(int i=0; i<inventoryList.Count; i++){
            if(inventoryList[i].itemCode == itemCode) return i;
        }

        return -1;
    }
    void AddItemPosition(List<InventoryItem> inventoryList, int itemCode){
        InventoryItem inventoryItem = new InventoryItem();

        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQuantity = 1;
        inventoryList.Add(inventoryItem);

        DebugPrintInventoryList(inventoryList);
    }

    void AddItemPosition(List<InventoryItem> inventoryList, int itemCode, int position){
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQuantity +1;
        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQuantity = quantity;
        inventoryList[position] = inventoryItem;

        DebugPrintInventoryList(inventoryList);
    }

    void DebugPrintInventoryList(List<InventoryItem> inventoryList){
        foreach(InventoryItem inventoryItem in inventoryList){
            Debug.Log("Item Description: " + InventoryManager.Instance.GetItemDetails(inventoryItem.itemCode).itemDescription + "   Item Quantity: " + inventoryItem.itemQuantity);
        }
        Debug.Log("********************************************");
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
