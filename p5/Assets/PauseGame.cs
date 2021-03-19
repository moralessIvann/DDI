using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool active;
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
     
     //new for p5
    public void pauseGame()
    {
        if(!(SimpleInput.GetKeyDown(KeyCode.P)))
        {
            active = ! active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0:1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            active = ! active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0:1f;
        }
    }
}
