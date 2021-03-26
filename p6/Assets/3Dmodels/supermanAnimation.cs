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

   public void AnimScale()
   {
       Anim.Play("ScaleSuperman",-1,0f);
       Anim.speed  = 0.3f;
   }
   public void AnimOriginalSize()
   {
       Anim.Play("OriginalSizeSuperman",-1,0f);
       Anim.speed  = 0.1f;
   }

    public void AnimRotate()
    {
        Anim.Play("RotateSuperman",-1,0f);
        Anim.speed  = 0.1f;
    }
}
