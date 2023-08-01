using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelStop : MonoBehaviour
{
    public Button stopLevel;
    public GameObject ComfortSetting;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = stopLevel.GetComponent<Button>();
		btn.onClick.AddListener(StopLevel);
    }

    /// <summary>
    /// Stop the current level for server side
    /// </summary>
    void StopLevel(){
        // Get music GameObject
        var music = GameObject.Find("Music_server");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        
        // Stop sound
        sound.Stop();

        // Destroy GameObject
        Destroy(music);

        // Update SkyBox to default
        var skybox = Resources.Load("materials/default") as Material;
        RenderSettings.skybox = skybox;

        //Remove phobie GameObject
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

        // Reset comfort settings
        var quit_button = ComfortSetting.GetComponent<ComfortPlayer>().quit;
        quit_button.interactable = true;
        var comfort_text = ComfortSetting.GetComponent<ComfortPlayer>().comfort_text;
        comfort_text.text = "Réconforter";
        ComfortSetting.GetComponent<ComfortPlayer>().is_active = false;

        // Update Sound and Skybox (CLIENT SIDE !)
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        skyboxPlayer.AddComponent<DataSync>();
        skyboxPlayer.GetComponent<DataSync>().DeleteData();

        // Update Gameobject (CLIENT SIDE !)
        GameObject phobiePlayer = GameObject.Find("phobiePlayer");
        phobiePlayer.AddComponent<DataSync>();
        phobiePlayer.GetComponent<DataSync>().DeletePhobie();
    }
}
