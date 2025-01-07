using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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

    }
}
