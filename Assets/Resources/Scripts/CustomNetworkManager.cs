using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

// This is a Custom class for NetworkManager
// It is used for override a current function in the abstract NetworkManager Class when a client connect to a server
public class CustomNetworkManager : NetworkManager
{
    public GameObject waitingScreen;
    public GameObject vueServeur;
    public GameObject checkPlatform;
    public GameObject waitingCamera;

    public override void OnServerConnect(NetworkConnectionToClient conn){
        Debug.Log("Client connected !");

        // We get 'Waiting' canva and hide his object (child + parent)
        var waitingClient = waitingScreen.transform.GetChild(0).gameObject;
        waitingClient.SetActive(false);
        waitingScreen.SetActive(false);

        // Show VueServeur (Only for server !)
        vueServeur.transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Client disconnected !");
        NetworkServer.DestroyPlayerForConnection(conn);

        var waitingClient = waitingScreen.transform.GetChild(0).gameObject;
        waitingClient.SetActive(true);
        waitingScreen.SetActive(true);

        // Hide VueServeur (Only for server !)
        vueServeur.transform.GetChild(0).gameObject.SetActive(false);
    }

    public override void OnClientDisconnect(){
        // Get and Show the research for server canva
        var waitingForServer = waitingScreen.transform.GetChild(1).gameObject;

        waitingForServer.SetActive(true);
        waitingScreen.SetActive(true);

        // Create a new temporary camera + Restart the discovery
        // This is used to avoid to restart the application in Android
        Debug.Log("Connection Lost !\n Research new server...");
        waitingCamera.GetComponent<CreateWaitingForServerCamera>().CreateCamera();
        checkPlatform.GetComponent<CheckPlatform>().SetupClient();
    }

}
