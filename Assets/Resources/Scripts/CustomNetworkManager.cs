using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

using static DataSync;

/// <summary>
/// This is a Custom class for NetworkManager
/// It is used for override a current function in the abstract NetworkManager Class when a client connect to a server
/// </summary>
public class CustomNetworkManager : NetworkManager
{
    public GameObject waitingScreen;
    public GameObject vueServeur;
    public GameObject checkPlatform;
    public GameObject waitingCamera;
    public GameObject ComfortSetting;

    private DataSync dataSync;

    new void Start(){
        dataSync = new DataSync();
    } 

    /// <summary>
    /// Called when a client connect to the server
    /// </summary>
    /// <param name="conn">The current connection between the client and the server</param>
    public override void OnServerConnect(NetworkConnectionToClient conn){
        Debug.Log("Client connected !");

        // We get 'Waiting' canva and hide his object (child + parent)
        var waitingClient = waitingScreen.transform.GetChild(0).gameObject;
        waitingClient.SetActive(false);
        waitingScreen.SetActive(false);

        // Show VueServeur (Only for server !)
        vueServeur.transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// Called when a client is disconnected for the server
    /// </summary>
    /// <param name="conn">The current connection between the client and the server</param>
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Client disconnected !");
        NetworkServer.DestroyPlayerForConnection(conn);

        var waitingClient = waitingScreen.transform.GetChild(0).gameObject;
        waitingClient.SetActive(true);
        waitingScreen.SetActive(true);

        // Remove sound
        dataSync.RemoveSound("Music_server");

        // Reset skybox to default
        dataSync.ResetSkybox();

        // Remove phobie GameObject
        dataSync.RemovePhobieGameObject();

        // Reset "Comfort" setting
        dataSync.ResetComfortSetting(ComfortSetting);
        
        // Hide VueServeur (Only for server !)
        foreach (Transform child in vueServeur.transform)
            child.gameObject.SetActive(false);
    }

    /// <summary>
    /// Called when a client lost the connection to a server
    /// </summary>
    public override void OnClientDisconnect(){
        // Get and Show the research for server canva
        var waitingForServer = waitingScreen.transform.GetChild(1).gameObject;

        waitingForServer.SetActive(true);
        waitingScreen.SetActive(true);

        // Remove sound
        dataSync.RemoveSound("Music_client");

        // Reset skybox to default
        dataSync.ResetSkybox();

        //Remove phobie GameObject
        dataSync.RemovePhobieGameObject();

        // Create a new temporary camera + Restart the discovery
        // This is used to avoid to restart the application in Android
        Debug.Log("Connection Lost !\n Research new server...");
        waitingCamera.GetComponent<CreateWaitingForServerCamera>().CreateCamera();
        checkPlatform.GetComponent<CheckPlatform>().SetupClient();
    }

}
