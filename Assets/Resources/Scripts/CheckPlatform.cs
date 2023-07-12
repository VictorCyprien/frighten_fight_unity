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
            // TODO : Fix message not appear in client phone
            waitingForServer = waitingScreen.transform.GetChild(1).gameObject;
            waitingForServer.SetActive(true);
            
            SetupClient();
        }
    }

    void SetupServer()
    {
        CurrentNetworkManager.StartServer();
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

        // Hide waitingForServer message 
        waitingForServer.SetActive(false);
        
        CurrentNetworkManager.StartClient(info.uri);
    }
}
