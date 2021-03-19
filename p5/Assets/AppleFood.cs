using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/Food")]
public class AppleFood : Item
{
    public int Hunger = 2;
    public override void Use()
    {
        base.Use();
        Debug.Log($"Decreasing hunger in {Hunger} unities");
        
    }
}
