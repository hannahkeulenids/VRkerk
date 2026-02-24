using Unity.Netcode;
using UnityEngine;

public class ConnectionLogger : MonoBehaviour
{
    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
            Debug.Log($"Client connected: {id}");
        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
            Debug.Log($"Client disconnected: {id}");
    }
}
