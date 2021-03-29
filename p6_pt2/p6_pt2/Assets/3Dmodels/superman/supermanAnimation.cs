using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supermanAnimation : MonoBehaviour
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
       Anim.Play("Shaking Hands",-1,0f);
       Anim.speed  = 1f;
   }

   public void movement2()
   {
       Anim.Play("Brutal Assassination",-1,0f);
       Anim.speed  = 1f;
   }

   public void movement3()
   {
       Anim.Play("Wave Hip Hop Dance",-1,0f);
       Anim.speed  = 0.8f;
   }
}
