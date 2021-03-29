using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batmanAnimation : MonoBehaviour
{
     private Animator Anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void movement1()
   {
       Anim.Play("Offensive Idle",-1,0f);
       Anim.speed  = 1f;
   }

   public void movement2()
   {
       Anim.Play("Back Flip To Uppercut",-1,0f);
       Anim.speed  = 0.7f;
   }

   public void movement3()
   {
       Anim.Play("Rumba Dancing",-1,0f);
       Anim.speed  = 0.8f;
   }
}
