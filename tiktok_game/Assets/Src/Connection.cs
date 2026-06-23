using NativeWebSocket;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private Message_Handler handlerScript;

    private GameObject settingObject;

    private WebSocket ws;

    async private void Start()
    {
        //Application.runInBackground = true; // Recommended for WebGL
        handlerScript = GetComponent<Message_Handler>();

        settingObject = GameObject.FindGameObjectWithTag("Setting");

        ws = new WebSocket("ws://127.0.0.1:8080");

        ws.OnOpen += () =>
        {
            Debug.Log("Connection open!");
            settingObject.SetActive(false);
        };

        ws.OnError += (e) => Debug.Log("Error! " + e);

        ws.OnClose += (code) =>
        {
            Debug.Log("Connection closed!");
            settingObject.SetActive(true);
        };

        ws.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            //Debug.Log("Received: " + message);

            handlerScript.HandleMessage(message);
        };

        await ws.Connect();
    }

    private void Update()
    {
        ws.DispatchMessageQueue();
    }

    private async void OnApplicationQuit()
    {
        await ws.Close();
    }

    async public void ReconnectToServer()
    {
        await ws.Connect();
    }
}
