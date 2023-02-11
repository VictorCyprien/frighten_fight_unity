using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

public class LevelStart : MonoBehaviour
{
    public GameObject levelChoice;
    public Scrollbar difficulty;
    public Button startLevel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startLevel.GetComponent<Button>();
		btn.onClick.AddListener(LoadLevel);
    }

    void LoadLevel(){
        // round to int to catch floating point problems.
        var level_difficulty = Mathf.RoundToInt(difficulty.value / (1f / (float) difficulty.numberOfSteps)) + 1;
        
        if (difficulty.value > 0.5){
            level_difficulty -= 1;
        }

        Debug.Log(levelChoice.tag);
        Debug.Log(level_difficulty);

        AudioClip sound = null;
        Material skybox = null;
        String sound_name = null;
        String skybox_name = null;

        switch (levelChoice.tag)
        {
            case "space":
                sound_name = "space";
                skybox_name = "spaceview";
                break;
            
            case "arachnophobie":
                sound_name = "space";
                skybox_name = "jungle1view";
                break;
            
            // Space level by default
            default:
                sound_name = "space";
                skybox_name = "spaceview";         
                break;
        }
        sound = Resources.Load($"sounds/{sound_name}") as AudioClip;
        skybox = Resources.Load($"materials/{skybox_name}") as Material;


        Debug.Log(sound);

        // Add music to play (server side)
        GameObject music = new GameObject("Music");
        music.AddComponent<AudioSource>();
        music.GetComponent<AudioSource>().clip = sound;
        music.GetComponent<AudioSource>().Play();

        // Update Skybox (server side)
        RenderSettings.skybox = skybox;

        // Update Sound and Skybox (CLIENT SIDE !)
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        skyboxPlayer.AddComponent<DataSync>();
        skyboxPlayer.GetComponent<DataSync>().UpdateData(sound_name, skybox_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
