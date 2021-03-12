using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//aniadir objetos a inventario usando clase Interactable
public class PickingUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        Inventory.InventoryInstance.Add(item);
        Destroy(this.gameObject);
    }
}
