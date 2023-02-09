using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CheckSkyBox : MonoBehaviour
{
    public AudioClip sound;
    public Material skybox;
    
    public void apply(){
        Debug.Log("APPLY NOW !");

        RenderSettings.skybox = skybox;
    }

}
