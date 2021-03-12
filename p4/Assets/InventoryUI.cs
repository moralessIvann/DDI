using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject panel;

    void Start()
    {
        _inventory = Inventory.InventoryInstance;
        _inventory.onChange += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            panel.SetActive(!panel.activeSelf);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        //Debug.Log("Inventory has changed");
        Slot[] slots =GetComponentsInChildren<Slot>();
        Item[] equipItems = _inventory.GetAllItemsByType(ItemType.Equip);
        Item[] lifeItems = _inventory.GetAllItemsByType(ItemType.Life);
        Item[] moneyItems = _inventory.GetAllItemsByType(ItemType.Money);
        Item[] otherItems = _inventory.GetAllItemsByType(ItemType.Other);
        Item[] bushItems = _inventory.GetAllItemsByType(ItemType.Bush);
        
        if (equipItems.Length > 0)
            slots[0].SetItem(equipItems[0], equipItems.Length);
        if (lifeItems.Length > 0)
            slots[1].SetItem(lifeItems[0], lifeItems.Length);
        if (moneyItems.Length > 0)
            slots[2].SetItem(moneyItems[0], moneyItems.Length);
        if (otherItems.Length > 0)
            slots[3].SetItem(otherItems[0], otherItems.Length);
        if (bushItems.Length > 0)
            slots[4].SetItem(bushItems[0], bushItems.Length);
/*        
        for(int i=0; i<slots.Length; i++)
        }
            if(i<_inventory.items.Count)
            {
                slots[i].SetItem(_inventory.items[i]);
            }
            else
            {
                slots[i].Clear();
            }
         
        }
*/        
    }   
}
