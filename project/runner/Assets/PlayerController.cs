using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private float desireLine = 1f;
    public float lineSpace = 4f;

    public float jumpForce;
    public float gravity = -20f;

    public Animator animator;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    //SpeechToText
    public string voiceCommand0 = "cero";//"salta";
    public string voiceCommand1 = "dos";//"derecha";
    public string voiceCommand2 = "uno";//"izquierda";
    
    // Start is called before the first frame update
    void Start()
    {
        VoiceProcessor commandProcessor = GameObject.FindObjectOfType<VoiceProcessor>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;
        
        //increasing speed each second
        if(forwardSpeed< maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime; 



        animator.SetBool("isGameStarted",true);
        direction.z = forwardSpeed;        
        

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if(isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }            
        }
        else
        {
            direction.y += gravity * Time.deltaTime;            
        }

        if(SwipeManager.swipeRight)//Input.GetKeyDown(KeyCode.RightArrow)
        {             
            TurnRight();           
        }

        if(SwipeManager.swipeLeft)//Input.GetKeyDown(KeyCode.LeftArrow)
        {          
            TurnLeft();
        }

        //calculate where to be in game
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desireLine == 0)
        {
            targetPosition += Vector3.left * lineSpace;
        }
        else if(desireLine == 2)
        {
            targetPosition += Vector3.right * lineSpace;
        }

        if(transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized *25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        if(!PlayerManager.isGameStarted)
            return;
        
        controller.Move(direction*Time.fixedDeltaTime);
    }

    public void Jump()
    {
        direction.y = jumpForce;
    }

    public void TurnRight()
    {
        desireLine++;
        if(desireLine > 3)
            desireLine = 2;
    }
    
    public void TurnLeft()
    {
        desireLine--;
        if(desireLine < 0)
            desireLine = 0;
    }

    public void TurnRightVoiceCommand()
    {
        desireLine ++;//= (float) 0.5;
        if(desireLine > 3)
            desireLine = 2;
    }

    public void TurnLeftVoiceCommand()
    {
        desireLine --;//= (float) 0.5;
        if(desireLine < 1)
            desireLine = 0;
    }

    public void OnVoiceCommandRecognized(string command)
    {
        if(command == voiceCommand0)
            Jump();  
        if(command == voiceCommand1)
            TurnRightVoiceCommand();
        if(command == voiceCommand2)
            TurnLeftVoiceCommand();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            PlayerManager.life = 0;
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}
