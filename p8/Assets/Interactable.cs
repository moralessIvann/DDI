using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;

public class Interactable : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    
    public string voiceCommand0 = "rojo";
    public string voiceCommand1 = "verde";
    public string voiceCommand2 = "azul";

    // Start is called before the first frame update
    void Start()
    {
        VoiceCommandProcessor commandProcessor = GameObject.FindObjectOfType<VoiceCommandProcessor>();
        commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
        x = 3; //default color
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
    }

    public void ChangeColorRed()
    {
        x = 0;
    }

    public void ChangeColorGreen()
    {
        x = 1;  
    }

    public void ChangeColorBlue()
    {
        x = 2;
    }

    public void OnVoiceCommandRecognized(string command)
    {
        if(command == voiceCommand0)
            ChangeColorRed();
        if(command == voiceCommand1)
            ChangeColorGreen();
        if(command == voiceCommand2)
            ChangeColorBlue();
    }
}
