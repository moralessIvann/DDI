using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject handPoint;
    public bool isInsideZone = false;
    private GameObject pickedObject = null;
    public KeyCode interactionKey = KeyCode.P;


    // Update is called once per frame
    public virtual void Update()
    {   
        //objetos para inventario
        if(isInsideZone && Input.GetKeyDown(interactionKey))
        {
                Interact();
        }

        //para agarrar objetos
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
    //para soltar objetos
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
} //singlenton : solo se puede instanciar un objeto a la vez en la clase.
