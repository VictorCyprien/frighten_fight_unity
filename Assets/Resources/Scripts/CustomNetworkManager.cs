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

    public override void OnServerConnect(NetworkConnectionToClient conn){
        // We get 'Waiting' canva and hide his object (child + parent)
        var waitingClient = waitingScreen.transform.GetChild(0).gameObject;
        waitingClient.SetActive(false);
        waitingScreen.SetActive(false);

        // Show VueServeur (Only for server !)
        vueServeur.transform.GetChild(0).gameObject.SetActive(true);
    }

}
