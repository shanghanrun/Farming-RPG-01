using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [ItemCodeDescription]
    
    [SerializeField] int _itemCode;
    SpriteRenderer sr;
    public int ItemCode{get {return _itemCode;} set{ _itemCode = value;}}

    void Awake(){
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Start(){
        if(ItemCode != 0){
            Init(ItemCode);
        }
    }

    public void Init(int itemCode){
        if (itemCode != 0)
        {
            ItemCode = itemCode;

            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(ItemCode);

            sr.sprite = itemDetails.itemSprite;

            // If item type is reapable(수확할 수 있는) then add nudgeable(쿡찌를 수 있는) component
            if (itemDetails.itemType == ItemType.ReapableScenery)
            {
                gameObject.AddComponent<ItemNudge>(); //스크립트로(자동으로) ItemNudge 스크립트 추가해서 해당인스턴스가 생길 수 있게 해서, 해당기능 작동하도록 한다.
            }
        }
    }
}
