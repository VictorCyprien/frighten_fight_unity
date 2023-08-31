using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

using static LevelDifficulty;
using static DataSync;

/// <summary>
/// This class launches the simulation of a level
/// </summary>
public class LevelStart : MonoBehaviour
{
    public GameObject levelChoice;
    public Scrollbar difficulty;
    public Button startLevel;

    public int minValue = 1;
    public int maxValue = 8;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Button btn = startLevel.GetComponent<Button>();
		btn.onClick.AddListener(LoadLevel);
    }

    /// <summary>
    /// Load the level selected for server side
    /// </summary>
    void LoadLevel(){
        // round to int to catch floating point problems.
        var level_difficulty = Mathf.RoundToInt(difficulty.value * (maxValue - minValue) + minValue);

        Debug.Log(levelChoice.tag);
        Debug.Log(level_difficulty);
        
        String sound_name = null;
        String skybox_name = null;

        LevelDifficulty choice = new LevelDifficulty();
        (skybox_name, sound_name) = choice.ChoiceLevelDifficulty(levelChoice.tag, level_difficulty);

        Debug.Log(skybox_name);
        Debug.Log(sound_name);

        DataSync dataSync = new DataSync();
        dataSync.CreateSound(sound_name, "Music_server");
        dataSync.UpdateSkybox(skybox_name);

        // Update Sound and Skybox (CLIENT SIDE !)
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        skyboxPlayer.AddComponent<ClientSync>();
        skyboxPlayer.GetComponent<ClientSync>().UpdateData(sound_name, skybox_name);

        // Update GameObject (CLIENT SIDE !)
        GameObject phobiePlayer = GameObject.Find("phobiePlayer");
        phobiePlayer.AddComponent<ClientSync>();
        phobiePlayer.GetComponent<ClientSync>().UpdatePhobie(levelChoice.tag, level_difficulty);
    }
}
