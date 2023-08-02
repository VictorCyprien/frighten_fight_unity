using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using static DataSync;

public class LevelStop : MonoBehaviour
{
    public Button stopLevel;
    public GameObject ComfortSetting;

    private DataSync dataSync;
    
    // Start is called before the first frame update
    void Start()
    {
        dataSync = new DataSync();
        Button btn = stopLevel.GetComponent<Button>();
		btn.onClick.AddListener(StopLevel);
    }

    /// <summary>
    /// Stop the current level for server side
    /// </summary>
    void StopLevel(){
        // Remove current sound
        dataSync.RemoveSound("Music_server");

        // Update SkyBox to default
        dataSync.ResetSkybox();

        //Remove phobie GameObject
        dataSync.RemovePhobieGameObject();

        // Reset comfort settings
        dataSync.ResetComfortSetting(ComfortSetting);

        // Update Sound and Skybox (CLIENT SIDE !)
        GameObject skyboxPlayer = GameObject.Find("skyboxPlayer");
        skyboxPlayer.AddComponent<ClientSync>();
        skyboxPlayer.GetComponent<ClientSync>().DeleteData();

        // Update Gameobject (CLIENT SIDE !)
        GameObject phobiePlayer = GameObject.Find("phobiePlayer");
        phobiePlayer.AddComponent<ClientSync>();
        phobiePlayer.GetComponent<ClientSync>().DeletePhobie();
    }
}
