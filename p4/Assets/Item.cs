using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip, Life, Money, Other, Bush
}

//create submenu in toolbar
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Generic")]

public class Item : ScriptableObject
{
    public ItemType itemType = ItemType.Equip;

    public Sprite icon = null;
    
    public virtual void Use()
    {
        Debug.Log($"using item {name}");
    }
}
