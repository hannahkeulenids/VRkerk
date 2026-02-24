using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class LanQuickConnect : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private UnityTransport transport;

    [Header("LAN")]
    [SerializeField] private string hostIp = "192.168.2.5";
    [SerializeField] private ushort port = 7777;

    [Header("Auto connect on Quest build")]
    [SerializeField] private bool autoStartClientOnDevice = true;

    void Start()
    {
#if !UNITY_EDITOR
        Debug.Log($"[LAN] Build started. AutoConnect={autoStartClientOnDevice} -> {hostIp}:{port}");
        if (autoStartClientOnDevice)
            StartClient();
#endif
    }

    public void StartHost()
    {
        if (transport == null)
            transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        string pcIp = "192.168.2.5"; // jouw PC IP
        transport.SetConnectionData(pcIp, port, "0.0.0.0"); // target IP + listen on all
        bool ok = NetworkManager.Singleton.StartHost();
        Debug.Log(ok ? "[LAN] HOST started" : "[LAN] HOST failed");
    }

    public void StartClient()
    {
        if (transport == null)
            transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        transport.SetConnectionData(hostIp, port);
        bool ok = NetworkManager.Singleton.StartClient();
        Debug.Log(ok ? $"[LAN] CLIENT connecting to {hostIp}:{port}" : "[LAN] CLIENT failed");
    }
}