using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{
    public GameObject handPoint;
    public bool isInsideZone = false;
    private GameObject pickedObject = null;
    public KeyCode interactionKey = KeyCode.P;
    
    //new for p5
    //public String interactionButton = "Interact";

    public void pickUpObjectBtn()
    {
        if(!(isInsideZone && Input.GetKeyDown(interactionKey)))
        {
            Interact();
        }
    }

    public virtual void Update()
    {   
        //tomar objetos para inventario
        //if(isInsideZone && Input.GetKeyDown(interactionKey))
        
        //new for p5
        if(isInsideZone && Input.GetKeyDown(interactionKey))
        {
            Interact();
        }

        //para soltar objetos
        if (pickedObject != null)
        {
            if(Input.GetKey("r")) //release
            {
                //GetComponent<AudioSource>().Play();
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
    }
    //para agarrar objetos
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if(Input.GetKey("g") && pickedObject == null) //grab
            {
                //GetComponent<AudioSource>().Play();
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }
  
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        //Debug.Log("Entró en el área");
        isInsideZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        //Debug.Log("Salió en el área");
        isInsideZone = false;
    }

    public virtual void Interact()
    {

    }
}
