using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;

public class LightActor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org"; 
    public int brokerPort = 1883;
	public string lightTopic = "casa/sala/luz";
    public int OnValue = 1;
    public int OffValue = 0;
    string lastMessage;
    private MqttClient client;
    public GameObject lightObject;
    volatile bool lightState = false;
    volatile bool lightStateFlag;
    
    void Start () 
    {     
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        string clientId = Guid.NewGuid().ToString(); 
        client.Connect(clientId);
        client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });      
    }

    void Update()
    {
        // if (lightState != lightObject.activeSelf)
		// 	lightObject.SetActive(lightState);
        if(lightStateFlag)
            lightObject.SetActive(true);
        else
            lightObject.SetActive(false);
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		int temp;
        int.TryParse(lastMessage, out temp);
        
        if(temp >= OnValue)
        {
            lightState = true;
            lightStateFlag = lightState;
        }
        else if(temp <= OffValue)
        {
            lightState = false;
            lightStateFlag = lightState;
        }
    }

     void OnApplicationQuit()
	{
		client.Disconnect();
	}
}