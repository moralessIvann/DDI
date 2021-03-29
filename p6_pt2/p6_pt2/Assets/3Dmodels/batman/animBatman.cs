using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class animBatman : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vb;
    public GameObject vb2;

    public Animator backFlipToUppercutAnim;
    public Animator rumbaDancingAnim;

    public GameObject _modelBackFlipToUppercut;
    public GameObject _modelRumbaDancing;

    
    // Start is called before the first frame update
    void Start()
    {
        vb = GameObject.Find("MovementBatman");
        vb2 = GameObject.Find("MovementBatman2");

        vb.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vb2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        _modelBackFlipToUppercut.SetActive(false);
        backFlipToUppercutAnim.GetComponent<Animator>().enabled = false;
        _modelRumbaDancing.SetActive(false);
        rumbaDancingAnim.GetComponent<Animator>().enabled = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch(vb.VirtualButtonName) {
            case "MovementBatman":
                _modelBackFlipToUppercut.SetActive(true);
                backFlipToUppercutAnim.GetComponent<Animator>().enabled = true;
                backFlipToUppercutAnim.Play("Back Flip To Uppercut");
                Debug.Log("btn pressed");
                    break;
            case "MovementBatman2":
                _modelRumbaDancing.SetActive(true);
                rumbaDancingAnim.GetComponent<Animator>().enabled = true;
                rumbaDancingAnim.Play("Rumba Dancing");
                Debug.Log("btn pressed");
                    break;
            default:
                    break;
        }
/*        
        backFlipToUppercutAnim.GetComponent<Animator>().enabled = true;
        backFlipToUppercutAnim.Play("Back Flip To Uppercut");
        Debug.Log("btn pressed");
*/
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch(vb.VirtualButtonName) {
            case "MovementBatman":
                _modelBackFlipToUppercut.SetActive(false);
                backFlipToUppercutAnim.GetComponent<Animator>().enabled = false;
                backFlipToUppercutAnim.Play("Back Flip To Uppercut");
                Debug.Log("btn pressed");
                    break;
            case "MovementBatman2":
                _modelRumbaDancing.SetActive(false);
                rumbaDancingAnim.GetComponent<Animator>().enabled = false;
                rumbaDancingAnim.Play("Rumba Dancing");
                Debug.Log("btn pressed");
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
