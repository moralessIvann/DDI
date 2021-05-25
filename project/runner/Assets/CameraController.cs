using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; //get the offset
    }

    // Update is called once per frame
    void LateUpdate() //to add smoothness
    {
        //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        Vector3 newPosition = new Vector3(transform.position.x, offset.y + target.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 160*Time.deltaTime); //newPosition;
    }
}
