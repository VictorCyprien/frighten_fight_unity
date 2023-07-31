using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using System;

public class DataSync : NetworkBehaviour
{

    /// <summary>
    /// Update the sound and skybox on client side
    /// </summary>
    /// <param name="sound_name">The name of the sound</param>
    /// <param name="skybox_name">The name of the skybox</param>
    [ClientRpc]
    public void UpdateSoundAndSkybox(String sound_name, String skybox_name)
    {
        Debug.Log("CLIENT !");

        // Add music to play (client side)
        AudioClip sound = Resources.Load($"sounds/{sound_name}") as AudioClip;
        GameObject music = new GameObject("Music_client");
        music.AddComponent<AudioSource>();
        music.GetComponent<AudioSource>().clip = sound;
        music.GetComponent<AudioSource>().loop = true;
        music.GetComponent<AudioSource>().Play();

        // Update Skybox (client side)
        Material skybox = Resources.Load($"materials/{skybox_name}") as Material;
        RenderSettings.skybox = skybox;
    }

    /// <summary>
    /// Add Spider or Snake GameObject for client side
    /// </summary>
    /// <param name="levelChoice">The current phobie selected</param>
    /// <param name="level_difficulty">The current difficulty of the level</param>
    [ClientRpc]
    public void UpdateGameObject(String levelChoice, int level_difficulty)
    {
        Debug.Log("CLIENT !");
        // Add Gameobject to client side
        GameObject current_phobie = null;
        switch (levelChoice)
        {   
            case "arachnophobie":
                if(level_difficulty == 6){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_6") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_client";
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 7){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_7") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_client";
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 8){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_8") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_client";
                    current_phobie.transform.position = spiderPosition;
                }

                break;

            case "acrophobie":
                break;

            case "ophiophobie":

                if (level_difficulty == 3)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_3") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 4)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/fake_snake/snake_level_4") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 5)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/crate_snake/snake_level_5") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 6){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_6") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 7){
                    var snakePrefab = Resources.Load("prefabs/snake/real_snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 8){
                    var snakePrefab = Resources.Load("prefabs/snake/real_snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                break;
        }
    }

    /// <summary>
    /// Remove current Spider or Snake GameObject for client side
    /// </summary>
    [ClientRpc]
    public void RemoveGameObject(){
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
    }

    /// <summary>
    /// Remove sound and reset skybox to default for client side
    /// </summary>
    [ClientRpc]
    public void DeleteSoundAndSkyBox(){
        // Get music GameObject
        var music = GameObject.Find("Music_client");

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

    /// <summary>
    /// Deactivate the level to comfort the player for client side
    /// </summary>
    /// <param name="current_level">The current phobie selected</param>
    [ClientRpc]
    public void DeactivateLevel(String current_level){
        // Get music GameObject
        var music = GameObject.Find("Music_client");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        sound.Pause();

        // Apply default skybox in function of current phobie
        Material skybox;
        switch(current_level){
            case "arachnophobie":
                Debug.Log("Comfort arachnophobie");
                skybox = Resources.Load("materials/comfort_arachnophobie") as Material;
                break;

            case "acrophobie":
                Debug.Log("Comfort acrophobie");
                skybox = Resources.Load("materials/comfort_acrophobie") as Material;
                break;

            case "ophiophobie":
                Debug.Log("Comfort ophiophobie");
                skybox = Resources.Load("materials/comfort_ophiophobie") as Material;
                break;

            default:
                Debug.Log("This should not arrive...");
                skybox = Resources.Load("materials/default") as Material;
                break;

        }

        RenderSettings.skybox = skybox;

        //Hide phobie GameObject
        var current_phobie = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g=>g.CompareTag("Spider"));

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Snake"));
        }

        if (current_phobie != null){
            current_phobie.SetActive(false);
        }
    }

    /// <summary>
    /// Reactivate the level for client side
    /// </summary>
    /// <param name="previous_skybox">The previous skybox used for the current level</param>
    [ClientRpc]
    public void ReactivateLevel(String previous_skybox){
        // Get music GameObject
        var music = GameObject.Find("Music_client");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        sound.UnPause();

        // Reapply previous skybox
        var previous_skybox_splited = previous_skybox.Split(" (")[0];
        RenderSettings.skybox = Resources.Load($"materials/{previous_skybox_splited}") as Material;

        //Show phobie GameObject
        var current_phobie = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g=>g.CompareTag("Spider"));

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Snake"));
        }

        if (current_phobie != null){
            current_phobie.SetActive(true);
        }
    }

    /// <summary>
    /// Liaison function that calls the main function to set the sound and the skybox for client side
    /// </summary>
    /// <param name="sound_name">The name of the sound</param>
    /// <param name="skybox_name">The name of the skybox</param>
    public void UpdateData(String sound_name, String skybox_name)
    {
        Debug.Log("UpdateSoundAndSkybox from client...");
        UpdateSoundAndSkybox(sound_name, skybox_name);
    }

    /// <summary>
    /// Liaison function that calls the main function to set Snake or Spider GameObject for client side
    /// </summary>
    /// <param name="levelChoice">The current phobie selected</param>
    /// <param name="level_difficulty">The current difficulty of the level</param>
    public void UpdatePhobie(String levelChoice, int level_difficulty)
    {
        Debug.Log("UpdateGameObject from client...");
        UpdateGameObject(levelChoice, level_difficulty);
    }

    /// <summary>
    /// Liaison function that calls the main function to remove the sound and the skybox for client side
    /// </summary>
    public void DeleteData(){
        Debug.Log("DeleteSoundAndSkyBox from client...");
        DeleteSoundAndSkyBox();
    }

    /// <summary>
    /// Liaison function that calls the main function to remove the Snake or Snider GameObject for client side
    /// </summary>
    public void DeletePhobie(){
        Debug.Log("DeleteGameObject from client...");
        RemoveGameObject();
    }

    /// <summary>
    /// Liaison function that calls the main function to deactivate or reactivate the level for client side
    /// </summary>
    /// <param name="is_active"></param>
    /// <param name="previous_skybox"></param>
    /// <param name="current_level"></param>
    public void Comfort(bool is_active, String previous_skybox, String current_level){
        if (!is_active){
            Debug.Log("Comfort from client...");
            DeactivateLevel(current_level);
            is_active = true;
        } else {
            Debug.Log("Reactive from client...");
            ReactivateLevel(previous_skybox);
            is_active = false;
        }
    }
}
