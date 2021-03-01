using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject handPoint;
    private GameObject pickedObject = null;


    // Update is called once per frame
    void Update()
    {
        if (pickedObject != null)
        {
            if(Input.GetKey("r")) //release
            {
                GetComponent<AudioSource>().Play();
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
            
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if(Input.GetKey("g") && pickedObject == null) //grab
            {
                GetComponent<AudioSource>().Play();
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }

        
    }
}
