using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    static protected Inventory s_InventoryInstance;
    static public Inventory InventoryInstance { get {return s_InventoryInstance; } }
    public int room = 10;
    public List<Item> items = new List<Item>();
    public delegate void OnChange();
    public OnChange onChange;

    void Awake() 
    {
        s_InventoryInstance = this;        
    }

    public Item[] GetAllItemsByType(ItemType type)
    {
        return items.Where(i => i.itemType == type).ToArray();
    }

    public void Add(Item newItem)
    {
        if(items.Count < room)
        {
            //if(newItem.GetType() == typeof){}
            
            items.Add(newItem);
            
            if(onChange != null)
            {
                onChange.Invoke();
            }
            
        }
        else
            Debug.Log("No room available");
    }

    public void Remove(Item removeItem)
    {
        if(items.Contains(removeItem))
            items.Remove(removeItem);
        else
            Debug.Log("No item in inventory");
    }
}
