using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;

public class TemperatureSensor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org"; 
    public int brokerPort = 1883;
	public string temperatureTopic = "temperatura";
    public string lightTopic = "luz";
    public float reportRate = 5f;
    public float temperatureValue = 20.3f;
    //public int lightValue = 0;
    private MqttClient client;
    private float reportTimer;
    
    void Start ()
    {     
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        string clientId = Guid.NewGuid().ToString(); 
        client.Connect(clientId);      
    }
	
    void Update()
    {
        if((reportTimer += Time.deltaTime) >= reportRate)
        {
            Debug.Log($"sending to topic {temperatureTopic}, value: {temperatureValue}");
			string message = temperatureValue.ToString();
            client.Publish(temperatureTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
            reportTimer = 0f;
        }
    }
}
