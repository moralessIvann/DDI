using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class MenuVirtualBtn : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject playVirtualBtnObj;
    public GameObject quitVirtualBtnObj;
    
    // Start is called before the first frame update
    void Start()
    {
        playVirtualBtnObj = GameObject.Find("PlayVirtualButton");
        playVirtualBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        quitVirtualBtnObj = GameObject.Find("QuitVirtualButton");
        quitVirtualBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        SceneManager.LoadScene("Level");
        //Debug.Log("Play Button Pressed");        
        /*
        switch(vb.VirtualButtonName) 
        {
            case "PlayVirtualButton":
               Debug.Log("Play Button Pressed");
                    break;
            case "QuitVirtualButton":
                Debug.Log("Quit Button Pressed");
                    break;
            default:
                    break;
        }
        */
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Application.Quit();
        //Debug.Log("Play Button Released");
        /*
        switch(vb.VirtualButtonName) 
        {
            case "PlayVirtualButton":
               Debug.Log("Play Button Released");
                    break;
            case "QuitVirtualButton":
                Debug.Log("Quit Button Released");
                    break;
            default:
                    break;
        }
        */ 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
