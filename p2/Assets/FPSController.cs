using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    CharacterController characterController;
    
    [Header("Character settings")]
    public float walkSpeed = 1.0f;
    public float runSpeed = 2.0f;
    public float jumpSpeed = 2.0f;
    public float gravity = 20.0f;

    [Header("Camara settings")]
    public Camera cams; 
    public float mouseHorizontal = 2.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = 2.0f;
    public float maxRotation = 2.0f;
    float h_mouse, v_mouse;

    private Vector3 move = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ///controlar camara usando mouse
        h_mouse = mouseHorizontal*Input.GetAxis("Mouse X");
        v_mouse = mouseVertical*Input.GetAxis("Mouse Y");
        
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cams.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);
        transform.Rotate(0, h_mouse, 0);
        
        if(characterController.isGrounded) //si hay contacto con el suelo, el caracter puede moverse
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift)) //el caracter se mueve si se detectan las teclas WASD o shift
                move = transform.TransformDirection(move) * runSpeed; 
            else
                move = transform.TransformDirection(move) * walkSpeed; 
                
            if(Input.GetKey(KeyCode.Space))
                move.y = jumpSpeed; 
        }

        move.y -= gravity * Time.deltaTime; //gravedad
        characterController.Move(move * Time.deltaTime);
    }
}
