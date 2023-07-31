using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;


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

    /// <summary>
    /// Remove the sound GameObject
    /// </summary>
    /// <param name="name">The name of the GameObject</param>
    private void RemoveSound(string name){
        var current_sound = GameObject.Find(name);

        if(current_sound != null){
            Destroy(current_sound);
        }
    }

    /// <summary>
    /// Reset the skybox at default value
    /// </summary>
    private void ResetSkybox(){
        var skybox = Resources.Load("materials/default") as Material;
        RenderSettings.skybox = skybox;
    }

    /// <summary>
    /// Reset the setting of comfort functionnality
    /// </summary>
    private void ResetComfortSetting(){
        var quit_button = ComfortSetting.GetComponent<ComfortPlayer>().quit;
        quit_button.interactable = true;
        var comfort_text = ComfortSetting.GetComponent<ComfortPlayer>().comfort_text;
        comfort_text.text = "Réconforter";
        ComfortSetting.GetComponent<ComfortPlayer>().is_active = false;
    }

    /// <summary>
    /// Remove GameObject of Snake and Spider
    /// </summary>
    private void RemovePhobieGameObject(){
        var current_phobie = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g=>g.CompareTag("Spider"));

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Snake"));
        }

        if (current_phobie != null){
            Destroy(current_phobie);
        }
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
        RemoveSound("Music_server");

        // Reset skybox to default
        ResetSkybox();

        // Remove phobie GameObject
        RemovePhobieGameObject();

        // Reset "Comfort" setting
        ResetComfortSetting();
        
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
        RemoveSound("Music_client");

        // Reset skybox to default
        ResetSkybox();

        //Remove phobie GameObject
        RemovePhobieGameObject();

        // Create a new temporary camera + Restart the discovery
        // This is used to avoid to restart the application in Android
        Debug.Log("Connection Lost !\n Research new server...");
        waitingCamera.GetComponent<CreateWaitingForServerCamera>().CreateCamera();
        checkPlatform.GetComponent<CheckPlatform>().SetupClient();
    }

}
