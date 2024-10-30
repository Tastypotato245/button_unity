using UnityEngine;
using WebSocketSharp;
using System.Net.Sockets;
using System.Text;

public class WebSocketManager : MonoBehaviour
{
    private WebSocket ws;
    private TcpClient tcpClient;
    private NetworkStream tcpStream;

    void Start()
    {
        // WebSocket 연결 설정
        ws = new WebSocket("ws://localhost:8080");
        ws.OnOpen += (sender, e) => Debug.Log("WebSocket Connection Opened");
        ws.OnMessage += (sender, e) => Debug.Log("Message from WebSocket server: " + e.Data);
        ws.OnError += (sender, e) => Debug.Log("WebSocket Error: " + e.Message);
        ws.OnClose += (sender, e) => Debug.Log("WebSocket Connection Closed");
        ws.Connect();

        // TCP 소켓 연결 설정
        tcpClient = new TcpClient();
        try
        {
            tcpClient.Connect("localhost", 8081);  // TCP 서버 IP와 포트로 연결
            tcpStream = tcpClient.GetStream();
            Debug.Log("TCP Connection Established");
        }
        catch (SocketException ex)
        {
            Debug.Log("TCP Connection Error: " + ex.Message);
        }
    }

    public void SendMessageToServer()
    {
        // WebSocket으로 메시지 전송
        if (ws != null && ws.IsAlive)
        {
            ws.Send("Button clicked via WebSocket!");
            Debug.Log("Message sent to WebSocket server: Button clicked via WebSocket!");
        }

        // TCP 소켓으로 메시지 전송
        if (tcpClient != null && tcpClient.Connected)
        {
            string message = "Button clicked via TCP!";
            byte[] data = Encoding.UTF8.GetBytes(message);
            tcpStream.Write(data, 0, data.Length);
            Debug.Log("Message sent to TCP server: Button clicked via TCP!");
        }
    }

    void OnDestroy()
    {
        // WebSocket 종료
        if (ws != null)
        {
            ws.Close();
            ws = null;
        }

        // TCP 소켓 종료
        if (tcpStream != null)
        {
            tcpStream.Close();
            tcpStream = null;
        }

        if (tcpClient != null)
        {
            tcpClient.Close();
            tcpClient = null;
        }
    }
}