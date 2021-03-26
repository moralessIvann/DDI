using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject panel;
    

    void Start()
    {
        _inventory = Inventory.InventoryInstance;
        _inventory.onChange += UpdateUI;
    }
    
    public void showInventory()
    {
          if(!(SimpleInput.GetKeyDown(KeyCode.I)))
        {
            panel.SetActive(!panel.activeSelf);
            UpdateUI();
        }
    }
    
    void Update()
    {
/*        
        if(Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeSelf);
            UpdateUI();
        }
*/       
    }

    void UpdateUI()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();       
       
        for(int i=0; i<slots.Length; i++)
        {
            if(i<_inventory.items.Count)
                slots[i].SetItem(_inventory.items[i]);
            else
                slots[i].Clear();
        }      
    }
}
