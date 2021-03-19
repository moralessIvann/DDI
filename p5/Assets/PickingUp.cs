using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        Inventory.InventoryInstance.Add(item); //add objects to inventory
        Destroy(this.gameObject); //destroy objectss from scene and not from inventory
    }
}
