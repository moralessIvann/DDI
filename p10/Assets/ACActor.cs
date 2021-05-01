using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;

public class ACActor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org"; //"localhost";
    public int brokerPort = 1883;
	public string temperatureTopic = "casa/sala/temperatura";
    public float temperatureUpperThreshold = 30f;
    public float temperatureLowerThreshold = 20f;
    string lastMessage;
    private MqttClient client;
    public GameObject acObject;
    volatile bool acState = false;
    volatile bool acStateFlag;
    
    void Start () 
    {     
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        string clientId = Guid.NewGuid().ToString(); 
        client.Connect(clientId);
        client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });      
    }

    void Update()
    {
        // if(acState != acObject.activeSelf)
		// 	acObject.SetActive(acState);
        if(acStateFlag)
            acObject.SetActive(true);
        else
            acObject.SetActive(false);
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		float temp;
        float.TryParse(lastMessage, out temp);
    
        if(temp >= temperatureUpperThreshold)
        {
            acState = true;
            acStateFlag = acState;
        }
        else if(temp <= temperatureLowerThreshold)
        {
            acState = false;
            acStateFlag = acState;
        }
    }

    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}