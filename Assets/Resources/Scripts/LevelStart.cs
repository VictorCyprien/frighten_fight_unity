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

        switch (levelChoice.tag)
        {
            case "space":
                sound = Resources.Load("sounds/space") as AudioClip;
                skybox = Resources.Load("materials/spaceview") as Material;
                break;
            default:
                break;
        }

        // var VueServeur = GameObject.Find("Player");
        // VueServeur.GetComponent<CheckSkyBox>().sound = sound;
        // VueServeur.GetComponent<CheckSkyBox>().skybox = skybox;

        Debug.Log(sound);

        // Add music to play
        GameObject m = new GameObject("Music");
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
        m.GetComponent<AudioSource>().Play();

        // Update Skybox
        RenderSettings.skybox = skybox;

        var skyboxPlayer = GameObject.Find("SkyboxPlayer");
        skyboxPlayer.AddComponent<CheckSkyBox>();
        skyboxPlayer.GetComponent<CheckSkyBox>().sound = sound;
        skyboxPlayer.GetComponent<CheckSkyBox>().skybox = skybox;
        skyboxPlayer.GetComponent<CheckSkyBox>().apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
