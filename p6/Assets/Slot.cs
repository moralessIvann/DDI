using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image image;

    public Sprite defaultSprite;
    public int counter = 0;
    public Text counterText;
    
    void Start()
    {
    }

    public void SetItem(Item item, int count = 0) 
    {
        counter = count;
        this.item = item;
        
        if(image != null)
        {
            image.enabled = true;
            image.sprite = item.icon;
        }
        if(counterText != null)
            counterText.text = counter.ToString();
    }

    public void Clear()
    {
        this.item = null;
        image.enabled = false;
    }

    //new

    public void UseItem()
    {
        if (this.item != null)
        {
            item.Use();

            if (counter > 0)
                counter--;
            if(counterText != null)
                counterText.text = counter.ToString();
        }
    }
}
