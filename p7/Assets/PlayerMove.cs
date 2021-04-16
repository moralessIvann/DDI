using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;
    bool inHands = false;
    Vector3 ballPos;

    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(!inHands)
            {
                ball.transform.SetParent(myHand.transform);
                ball.transform.localPosition = new Vector3(0f,-0.98f,0f);//(1.76f,2.75f,-0.00999f);
                inHands = true;
            }
            else if(inHands)
            {
                ball.transform.SetParent(null);
                ball.transform.localPosition = ballPos;
                inHands = false;
            }
            
        }
        
    }
}
