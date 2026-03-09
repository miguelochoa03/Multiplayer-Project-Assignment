using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    public void StartHost()
    {
        var transport = NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        //transport.ConnectionData.Address = "192.168.1.226";
        transport.ConnectionData.Address = "192.168.1.235";
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient()
    {
        var transport = NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        //transport.ConnectionData.Address = "192.168.1.226";
        transport.ConnectionData.Address = "192.168.1.235";
        NetworkManager.Singleton.StartClient();
    }
}
