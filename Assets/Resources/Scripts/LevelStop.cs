using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
