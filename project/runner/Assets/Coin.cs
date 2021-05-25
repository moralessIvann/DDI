﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(200 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numofCoins += 1;
            FindObjectOfType<AudioManager>().PlaySound("CoinSound");
            //Debug.Log("Coins: " + PlayerManager.numofCoins);
            Destroy(gameObject);
        }
    }
}
