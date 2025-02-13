using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttribute))]
public class ItemCodeDescriptionDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
        return EditorGUI.GetPropertyHeight(property) * 2; // 두배 높이
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        if(property.propertyType == SerializedPropertyType.Integer){
            EditorGUI.BeginChangeCheck(); // Start of check for changed values

            // Draw item code
            var newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, position.height/2), label, property.intValue);

            // Draw item Description
            EditorGUI.LabelField(new Rect(position.x, position.y + position.height/2, position.width, position.height/2), "Item Description", GetItemDescription(property.intValue));

            // if item code value has changed, then set value to new value
            if(EditorGUI.EndChangeCheck()){
                property.intValue = newValue;
            }
        }
    }

    string GetItemDescription(int itemCode){
        SO_ItemList so_itemList;

        so_itemList = AssetDatabase.LoadAssetAtPath("Assets/Scriptable Object Assets/Item/so_ItemList.asset", typeof(SO_ItemList)) as SO_ItemList;

        List<ItemDetails> itemDetailsList = so_itemList.itemDetails;

        ItemDetails itemDetails = itemDetailsList.Find(x => x.itemCode == itemCode);

        if(itemDetails != null){
            return itemDetails.itemDescription;
        }
        else{
            return "";
        }
    }
}
