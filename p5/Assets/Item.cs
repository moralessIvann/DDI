using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip, Life, Money, Rock, Food
    //GetEquip, GetLife, GetMoney, GetRock, GetFood
}
//create asset from menu 
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Generic")]
public class Item : ScriptableObject
{
    public ItemType itemType = ItemType.Equip;
    public Sprite icon = null;    
    public virtual void Use()
    {
        Debug.Log($"Using item {name}");
    }
}
