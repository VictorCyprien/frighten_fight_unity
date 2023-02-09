using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;


public class CheckSkyBox : NetworkBehaviour
{

    [ClientRpc]
    public void updateSkyboxClient(){
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        // skyboxPlayer.GetComponent<NetworkIdentity>().assetId = 608131090;
        
    }
    
    public void apply(){
        Debug.Log("APPLY NOW !");
        // if(isServer){
        //     Debug.Log("I'M SERVER !");
        // }
        updateSkyboxClient();
    }

}
