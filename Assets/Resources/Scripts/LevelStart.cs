using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

using static LevelDifficulty;

public class LevelStart : MonoBehaviour
{
    public GameObject levelChoice;
    public Scrollbar difficulty;
    public Button startLevel;

    public int minValue = 1;
    public int maxValue = 8;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startLevel.GetComponent<Button>();
		btn.onClick.AddListener(LoadLevel);
    }

    void LoadLevel(){
        // round to int to catch floating point problems.
        var level_difficulty = Mathf.RoundToInt(difficulty.value * (maxValue - minValue) + minValue);

        Debug.Log(levelChoice.tag);
        Debug.Log(level_difficulty);

        AudioClip sound = null;
        Material skybox = null;
        String sound_name = null;
        String skybox_name = null;

        LevelDifficulty choice = new LevelDifficulty();
        (skybox_name, sound_name) = choice.ChoiceLevelDifficulty(levelChoice.tag, level_difficulty);

        Debug.Log(skybox_name);
        Debug.Log(sound_name);

        sound = Resources.Load($"sounds/{sound_name}") as AudioClip;
        skybox = Resources.Load($"materials/{skybox_name}") as Material;

        // Add music to play (server side)
        GameObject music = new GameObject("Music_server");
        music.AddComponent<AudioSource>();
        music.GetComponent<AudioSource>().clip = sound;
        music.GetComponent<AudioSource>().loop = true;
        music.GetComponent<AudioSource>().Play();

        // Update Skybox (server side)
        RenderSettings.skybox = skybox;

        // Reset comfort var (set to false) to avoid duplicate GameObject
        var comfort = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g=>g.CompareTag("Comfort"));
        comfort.GetComponent<ComfortPlayer>().is_active = false;

        // Update Sound and Skybox (CLIENT SIDE !)
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        skyboxPlayer.AddComponent<DataSync>();
        skyboxPlayer.GetComponent<DataSync>().UpdateData(sound_name, skybox_name);

        // Update GameObject (CLIENT SIDE !)
        GameObject phobiePlayer = GameObject.Find("phobiePlayer");
        phobiePlayer.AddComponent<DataSync>();
        phobiePlayer.GetComponent<DataSync>().UpdatePhobie(levelChoice.tag, level_difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
