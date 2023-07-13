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
    public GameObject vueServeur;
    public GameObject waitingCamera;

    private NetworkDiscovery discovery;
    private GameObject waitingClient;
    private GameObject waitingForServer;
    private NetworkManager CurrentNetworkManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get NetworkManager component
        CurrentNetworkManager = networkManager.GetComponent<CustomNetworkManager>();

        if (DEBUG){
            CurrentNetworkManager.StartServer();
            CurrentNetworkManager.StartClient();
            return;
        }

        // Show waitingScreen Canva
        waitingScreen.SetActive(true);

        RuntimePlatform platform = Application.platform;
        discovery = networkManager.GetComponent<NetworkDiscovery>();

        if (platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer)
        {
            Debug.Log("Application is running on Windows");
            
            // Hide current VueServeur
            vueServeur.transform.GetChild(0).gameObject.SetActive(false);
            
            // Show waitingclient message
            waitingClient = waitingScreen.transform.GetChild(0).gameObject;
            waitingClient.SetActive(true);
            
            SetupServer();
        }
        else if (platform == RuntimePlatform.Android)
        {
            Debug.Log("Application is running on Android");
            Screen.orientation = ScreenOrientation.LandscapeLeft;

            // Show waitingForServer message
            waitingForServer = waitingScreen.transform.GetChild(1).gameObject;
            waitingForServer.SetActive(true);

            // Create temporary camera to see the message
            waitingCamera.GetComponent<CreateWaitingForServerCamera>().CreateCamera();
            
            SetupClient();
        }
    }

    void SetupServer()
    {
        CurrentNetworkManager.StartServer();
        discovery.AdvertiseServer();
        Debug.Log("Server is ok !\nNow listening to connection...");
    }

    public void SetupClient()
    {
        Debug.Log(discovery);
        discovery.StartDiscovery();
    }

    // Called when client found a server
    public void OnDiscoveredServer(ServerResponse info)
    {
        Debug.Log($"Server found : {info.EndPoint.Address.ToString()}");
        Connect(info);
    }

    void Connect(ServerResponse info)
    {
        discovery.StopDiscovery();

        // Hide waitingForServer message + Hide waitingScreen Canva
        waitingForServer.SetActive(false);
        waitingScreen.SetActive(false);

        // Destroy the temporary camera
        waitingCamera.GetComponent<CreateWaitingForServerCamera>().DestroyCamera();
        
        CurrentNetworkManager.StartClient(info.uri);
    }
}
