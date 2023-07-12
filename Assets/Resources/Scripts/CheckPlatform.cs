using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Discovery;

public class CheckPlatform : MonoBehaviour
{
    public bool DEBUG;
    public GameObject networkManager;
    public GameObject waitingScreen;
    private NetworkDiscovery discovery;

    private GameObject waitingClient;
    private GameObject waitingForServer;

    // Start is called before the first frame update
    void Start()
    {
        if (DEBUG){
            NetworkManager.singleton.StartServer();
            NetworkManager.singleton.StartClient();
            return;
        }

        RuntimePlatform platform = Application.platform;
        discovery = networkManager.GetComponent<NetworkDiscovery>();

        if (platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer)
        {
            Debug.Log("Application is running on Windows");
            waitingClient = waitingScreen.transform.GetChild(0).gameObject;
            waitingClient.SetActive(true);
            SetupServer();
        }
        else if (platform == RuntimePlatform.Android)
        {
            Debug.Log("Application is running on Android");
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            waitingForServer = waitingScreen.transform.GetChild(1).gameObject;
            waitingForServer.SetActive(true);
            SetupClient();
        }
    }

    void SetupServer()
    {
        NetworkManager.singleton.StartServer();
        discovery.AdvertiseServer();
        Debug.Log("Server is ok !\nNow listening to connection...");
    }

    void SetupClient()
    {
        Debug.Log(discovery);
        discovery.StartDiscovery();
    }

    // Called when client found a server
    public void OnDiscoveredServer(ServerResponse info)
    {
        Debug.Log(info.EndPoint.Address.ToString());
        Connect(info);
    }

    void Connect(ServerResponse info)
    {
        discovery.StopDiscovery();
        waitingForServer.SetActive(false);
        NetworkManager.singleton.StartClient(info.uri);
    }

    // Called when a client connect to a server
    void OnClientConnect(){
        // WIP
        return;
    }

}
