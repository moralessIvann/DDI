using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class animDarkseid : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vb;
    public GameObject vb2;

    public Animator flyingPunchAnim;
    public Animator BrooklynUprockAnim;

    public GameObject _modelflyingPunch;
    public GameObject _modelBrooklynUprock;

    
    // Start is called before the first frame update
    void Start()
    {
        vb = GameObject.Find("MovementDarkseid");
        vb2 = GameObject.Find("MovementDarkseid2");
        
        vb.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vb2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
        _modelflyingPunch.SetActive(false);
        flyingPunchAnim.GetComponent<Animator>().enabled = false;
        _modelBrooklynUprock.SetActive(false);
        BrooklynUprockAnim.GetComponent<Animator>().enabled = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch(vb.VirtualButtonName) {
            case "MovementDarkseid":
                _modelflyingPunch.SetActive(true);
                flyingPunchAnim.GetComponent<Animator>().enabled = true;
                flyingPunchAnim.Play("Flying Knee Punch Combo");
                Debug.Log("btn pressed");
                    break;
            case "MovementDarkseid2":
                _modelBrooklynUprock.SetActive(true);
                BrooklynUprockAnim.GetComponent<Animator>().enabled = true;
                BrooklynUprockAnim.Play("Brooklyn Uprock");
                Debug.Log("btn pressed");
                    break;
            default:
                    break;
        }
        
/*        
        flyingPunchAnim.GetComponent<Animator>().enabled = true;
        flyingPunchAnim.Play("Flying Knee Punch Combo");
        Debug.Log("btn pressed");
*/
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        switch(vb.VirtualButtonName) {
            case "MovementDarkseid":
                _modelflyingPunch.SetActive(false);
                flyingPunchAnim.GetComponent<Animator>().enabled = false;
                flyingPunchAnim.Play("None");
                Debug.Log("btn released");
                    break;
            case "MovementDarkseid2":
                _modelBrooklynUprock.SetActive(false);
                BrooklynUprockAnim.GetComponent<Animator>().enabled = false;
                BrooklynUprockAnim.Play("None");
                Debug.Log("btn released");
                    break;
            default:
                    break;
        }   
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
