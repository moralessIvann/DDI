using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{
  
    public bool isInsideZone = false;
    public string interactionButton = "Interact";

    public virtual void Update()
    {   
        if(isInsideZone && CrossPlatformInputManager.GetButtonDown(interactionButton))
        {
            Interact();
        }
        
/*
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
 */ 
    }
/*    
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
 */ 
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        //Debug.Log("Entró en el área");
        isInsideZone = true;
    }

    void OnMouseDown() 
    {
        Interact();
        Debug.Log("Click");
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
