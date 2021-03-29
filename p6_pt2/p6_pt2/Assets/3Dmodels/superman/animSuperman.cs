using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class animSuperman : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vb;
    public GameObject vb2;

    public Animator BrutalAnim;
    public Animator WaveHipHopDanceAnim;

    public GameObject _modelWaveHipHopDance;
    public GameObject _modelBrutalAssassination;

    
    // Start is called before the first frame update
    void Start()
    {
        vb = GameObject.Find("MovementSuperman");
        vb2 = GameObject.Find("MovementSuperman2");

        vb.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vb2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        _modelBrutalAssassination.SetActive(false);
        BrutalAnim.GetComponent<Animator>().enabled = false;
        _modelWaveHipHopDance.SetActive(false);
        WaveHipHopDanceAnim.GetComponent<Animator>().enabled = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch(vb.VirtualButtonName) {
            case "MovementSuperman":
                _modelBrutalAssassination.SetActive(true);
                BrutalAnim.GetComponent<Animator>().enabled = true;
                BrutalAnim.Play("Brutal Assassination");
                Debug.Log("btn pressed");
                    break;
            case "MovementSuperman2":
                _modelWaveHipHopDance.SetActive(true);
                WaveHipHopDanceAnim.GetComponent<Animator>().enabled = true;
                WaveHipHopDanceAnim.Play("Wave Hip Hop Dance");
                Debug.Log("btn pressed");
                    break;
            default:
                    break;
        }
/*        
        BrutalAnim.GetComponent<Animator>().enabled = true;
        BrutalAnim.Play("Brutal Assassination");
        Debug.Log("btn pressed");
*/
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch(vb.VirtualButtonName) {
            case "MovementSuperman":
                _modelBrutalAssassination.SetActive(false);
                BrutalAnim.GetComponent<Animator>().enabled = false;
                BrutalAnim.Play("None");
                Debug.Log("btn pressed");
                    break;
            case "MovementSuperman2":
               _modelWaveHipHopDance.SetActive(false);
                WaveHipHopDanceAnim.GetComponent<Animator>().enabled = false;
                WaveHipHopDanceAnim.Play("None");
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
