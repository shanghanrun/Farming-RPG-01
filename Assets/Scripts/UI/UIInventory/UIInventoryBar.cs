using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    [SerializeField] Sprite blank16x16sprite = null;
    [SerializeField] UIInventorySlot[] inventorySlots = null;

    RectTransform rectTr;
    bool _isInventoryBarPositionBottom = true;
    public bool IsInventoryBarPositionBottom {get => _isInventoryBarPositionBottom;
                                            set => _isInventoryBarPositionBottom = value; }

    void Awake(){
        rectTr = GetComponent<RectTransform>();
    }

    void OnEnable() {
        EventHandler.InventoryUpdatedEvent += InventoryUpdated;
    }
    void OnDisable() {
        EventHandler.InventoryUpdatedEvent -= InventoryUpdated;
    }

    void Update(){
        SwitchInventoryBarPosition();
    }

    void SwitchInventoryBarPosition(){
        Vector3 playerViewportPosition = Player.Instance.GetPlayerViewportPosition();

        if(playerViewportPosition.y > .3f && IsInventoryBarPositionBottom == false){
            //transform.position = new Vector3(transform.position.x, 7.5f. 0f); // this was changed to control the recttransform see below
            rectTr.pivot = new Vector2(.5f, 0f);
            rectTr.anchorMin = new Vector2(.5f, 0f);
            rectTr.anchorMax = new Vector2(.5f,0f);
            rectTr.anchoredPosition = new Vector2(0f, 2.5f);

            IsInventoryBarPositionBottom = true;
        }
        else if(playerViewportPosition.y <= .3f && IsInventoryBarPositionBottom == true){
            //transform.position = new Vector3(transform.position.x, mainCamera.pixelHeight - 120f, 0f); // this was changed to control the recttransform see below
            rectTr.pivot = new Vector2(.5f, 1f);
            rectTr.anchorMin = new Vector2(.5f, 1f);
            rectTr.anchorMax = new Vector2(.5f, 1f);
            rectTr.anchoredPosition = new Vector2(0f, -2.5f);

            IsInventoryBarPositionBottom = false;
        }
    }

    void InventoryUpdated(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList){
        if(inventoryLocation == InventoryLocation.player){

            ClearInventorySlots();

            if(inventorySlots.Length >0 && inventoryList.Count >0){
                for(int i=0; i< inventoryList.Count; i++){
                    if(i < inventoryList.Count){
                        int itemCode = inventoryList[i].itemCode;

                        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);

                        if(itemDetails !=null){
                            //인벤토리 아이템슬롯에 이미지와 디테일즈를 넣기
                            inventorySlots[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                            inventorySlots[i].textMeshProUGUI.text = inventoryList[i].itemQuantity.ToString();
                            inventorySlots[i].itemDetails = itemDetails;
                            inventorySlots[i].itemQuantity = inventoryList[i].itemQuantity;
                        }
                    }
                    else{
                        break;
                    }
                }
            }
        }
    }

    void ClearInventorySlots(){
        if(inventorySlots.Length >0){
            for(int i=0; i< inventorySlots.Length; i++){
                inventorySlots[i].inventorySlotImage.sprite = blank16x16sprite;
                inventorySlots[i].textMeshProUGUI.text ="";
                inventorySlots[i].itemDetails = null;
                inventorySlots[i].itemQuantity = 0;
            }
        }
    }
}
