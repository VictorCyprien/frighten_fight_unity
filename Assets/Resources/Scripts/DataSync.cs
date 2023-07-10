using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using System;

public class DataSync : NetworkBehaviour
{

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
                if(level_difficulty == 6){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_6") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 7){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 8){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_8") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_client";
                    current_phobie.transform.position = snakePosition;
                }

                break;
        }
    }

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

    [ClientRpc]
    public void DeactivateLevel(){
        // Get music GameObject
        var music = GameObject.Find("Music_client");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        sound.Pause();

         // Apply default skybox for now
        var skybox = Resources.Load("materials/default") as Material;
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

    public void UpdateData(String sound_name, String skybox_name)
    {
        Debug.Log("UpdateSoundAndSkybox from client...");
        UpdateSoundAndSkybox(sound_name, skybox_name);
    }

    public void UpdatePhobie(String levelChoice, int level_difficulty)
    {
        Debug.Log("UpdateGameObject from client...");
        UpdateGameObject(levelChoice, level_difficulty);
    }

    public void DeleteData(){
        Debug.Log("DeleteSoundAndSkyBox from client...");
        DeleteSoundAndSkyBox();
    }

    public void DeletePhobie(){
        Debug.Log("DeleteGameObject from client...");
        RemoveGameObject();
    }

    public void Comfort(bool is_active, String previous_skybox){
        if (!is_active){
            Debug.Log("Comfort from client...");
            DeactivateLevel();
            is_active = true;
        } else {
            Debug.Log("Reactive from client...");
            ReactivateLevel(previous_skybox);
            is_active = false;
        }
    }
}
