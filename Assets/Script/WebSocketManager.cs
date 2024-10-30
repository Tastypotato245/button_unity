using UnityEngine;
using WebSocketSharp;

public class WebSocketManager : MonoBehaviour
{
    private WebSocket ws;

    void Start()
    {
        ws = new WebSocket("ws://localhost:8080");

        ws.OnOpen += (sender, e) => Debug.Log("Connection Opened");
        ws.OnMessage += (sender, e) => Debug.Log("Message from server: " + e.Data);
        ws.OnError += (sender, e) => Debug.Log("Error: " + e.Message);
        ws.OnClose += (sender, e) => Debug.Log("Connection Closed");

        ws.Connect();
    }

    void OnDestroy()
    {
        ws.Close();
    }
}
