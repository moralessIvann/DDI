using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameOverVirtualBtn: MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject againVB;
    public GameObject quitVB;
    
    // Start is called before the first frame update
    void Start()
    {
        againVB = GameObject.Find("AgainVirtualButton");
        quitVB = GameObject.Find("QuitVirtualButton");
        againVB.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        quitVB.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
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
