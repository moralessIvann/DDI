using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCPlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity =- 9.8f;
    public float jumpHeight = 3;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    bool fpc_jump;
    
    //new for p5
    public void Jump()
    {
        if(!(Input.GetButtonDown("Jump") && isGrounded))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    
    void Start()
    {
        /*
        //disable to move joystick in p5
        Cursor.lockState = CursorLockMode.Locked;
        */
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        
        /* //commented in p5
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        */

        //new for p5
        float x = SimpleInput.GetAxis("Horizontal");
        float z = SimpleInput.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);

        //used for 'Jump' method in line19
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
