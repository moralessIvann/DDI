using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Villain, Hero
}

[CreateAssetMenu(fileName = "New character", menuName = "Inventory/Character")]
public class DCcharacters : Item
{
    public CharacterType characterType = CharacterType.Villain;
    //public Sprite icon = null;    
   
}
