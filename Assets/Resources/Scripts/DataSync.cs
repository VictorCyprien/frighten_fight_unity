using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class DataSync : NetworkBehaviour
{
    [SyncVar]
    public int num = 1;

    [SyncVar]
    public String sound = null;
    
    [SyncVar]
    public String skybox = null;


    [ClientRpc]
    public void UpdateSoundAndSkybox(String sound_name, String skybox_name)
    {
        Debug.Log("CLIENT !");

        // Add music to play (client side)
        AudioClip sound = Resources.Load($"sounds/{sound_name}") as AudioClip;
        GameObject music = new GameObject("Music");
        music.AddComponent<AudioSource>();
        music.GetComponent<AudioSource>().clip = sound;
        music.GetComponent<AudioSource>().loop = true;
        music.GetComponent<AudioSource>().Play();

        // Update Skybox (client side)
        Material skybox = Resources.Load($"materials/{skybox_name}") as Material;
        RenderSettings.skybox = skybox;
    }

    [ClientRpc]
    public void DeleteSoundAndSkyBox(){
        // Get music GameObject
        var music = GameObject.Find("Music");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        
        // Stop sound
        sound.Stop();

        // Destroy GameObject
        Destroy(music);

        // Update SkyBox to default
        var skybox = Resources.Load("materials/default") as Material;
        RenderSettings.skybox = skybox;
    }

    public void UpdateData(String sound_name, String skybox_name)
    {
        Debug.Log("UpdateSoundAndSkybox from client...");
        UpdateSoundAndSkybox(sound_name, skybox_name);
    }

    public void DeleteData(){
        Debug.Log("DeleteSoundAndSkyBox from client...");
        DeleteSoundAndSkyBox();
    }
}
