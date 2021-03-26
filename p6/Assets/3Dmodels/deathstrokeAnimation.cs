using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathstrokeAnimation : MonoBehaviour
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
       Anim.Play("ScaleDeathstroke",-1,0f);
       Anim.speed  = 0.3f;
   }
   public void AnimOriginalSize()
   {
       Anim.Play("OriginalSizeDeathstroke",-1,0f);
       Anim.speed  = 0.1f;
   }

    public void AnimRotate()
    {
        Anim.Play("RotateDeathstroke",-1,0f);
        Anim.speed  = 0.1f;
    }
}
