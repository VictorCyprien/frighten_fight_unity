using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStop : MonoBehaviour
{
    public Button stopLevel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = stopLevel.GetComponent<Button>();
		btn.onClick.AddListener(StopLevel);
    }

    void StopLevel(){
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

        // Update Sound and Skybox (CLIENT SIDE !)
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        skyboxPlayer.AddComponent<DataSync>();
        skyboxPlayer.GetComponent<DataSync>().DeleteData();
    }
}
