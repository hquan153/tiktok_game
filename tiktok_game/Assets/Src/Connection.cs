using UnityEngine;
using NativeWebSocket;

public class Connection : MonoBehaviour
{
    private WebSocket ws;

    async void Start()
    {
        //Application.runInBackground = true; // Recommended for WebGL

        ws = new WebSocket("ws://127.0.0.1:8080");

        ws.OnOpen += () => Debug.Log("Connection open!");
        ws.OnError += (e) => Debug.Log("Error! " + e);
        ws.OnClose += (code) => Debug.Log("Connection closed!");

        ws.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("Received: " + message);
        };

        await ws.Connect();
    }

    void Update()
    {
        ws.DispatchMessageQueue();
    }
}
