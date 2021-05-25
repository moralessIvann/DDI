using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    //public GameObject startingText;
    public static int numofCoins;
    public static int life;
    public Text coinsText;
    public Text lifeText;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = true;
        numofCoins = 0;
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            //life = 0;
            gameOverPanel.SetActive(true);
        }
/*
        if(SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
*/
        coinsText.text = "Monedas  " + numofCoins;
        lifeText.text = "Vida " + life;
    }
}
