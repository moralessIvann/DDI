using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        //load main scene
        SceneManager.LoadScene("Level"); 
        //SceneManager.LoadScene("vuforia&voice"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
