using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Discovery;

public class CheckPlatform : MonoBehaviour
{
    public bool DEBUG;
    public NetworkDiscovery networkDiscovery;
    // Start is called before the first frame update
    void Start()
    {
        if (DEBUG){
            NetworkManager.singleton.StartServer();
            NetworkManager.singleton.StartClient();
            return;
        }

        RuntimePlatform platform = Application.platform;
        
        if (platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer)
        {
            Debug.Log("Application is running on Windows");
            SetupServer();
        }
        else if (platform == RuntimePlatform.Android)
        {
            Debug.Log("Application is running on Android");
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            SetupClient();
            // networkDiscovery.StartAsClient();
        }
    }

    void SetupServer()
    {
        NetworkManager.singleton.StartServer();
    }

    void SetupClient()
    {
        //NetworkManager.singleton.StartClient();
        networkDiscovery.Start();
    }

    // Called when client found a server
    void OnDiscoveredServer(DiscoveryResponse info)
    {
        Debug.Log("Server discovered: " + info);

        // Connect to server
        // NetworkManager.singleton.StartClient(info);
    }
}
