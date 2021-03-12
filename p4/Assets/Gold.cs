using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gold", menuName = "Inventory/Money")]
public class Gold : Item
{
    public int coins = 0;
    public override void Use()
    {
        base.Use();
        //Debug.Log("Money up");
        
    }

}
