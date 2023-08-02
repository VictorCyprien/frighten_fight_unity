using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Basic class to call methods for both server and client side
/// This is very useful to avoid to repeat some code with very minor changes
/// </summary>
public class DataSync : MonoBehaviour
{
    /// <summary>
    /// Create a GameObject with AudioSource Component
    /// </summary>
    /// <param name="sound_name">The name of the sound in the ressources folder</param>
    /// <param name="object_name">The name of the object</param>
    public void CreateSound(string sound_name, string object_name){
        // Add music to play
        AudioClip sound = Resources.Load($"sounds/{sound_name}") as AudioClip;
        GameObject music = new GameObject(object_name);
        music.AddComponent<AudioSource>();
        music.GetComponent<AudioSource>().clip = sound;
        music.GetComponent<AudioSource>().loop = true;
        music.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Pause the sound of a GameObject with AudioSource Component
    /// </summary>
    /// <param name="sound_name">The name of the GameObject</param>
    public void PauseSound(string sound_name){
        var music = GameObject.Find(sound_name);
        var sound = music.GetComponent<AudioSource>();
        sound.Pause();
    }

    /// <summary>
    /// Resume the sound of a GameObject with AudioSource Component
    /// </summary>
    /// <param name="sound_name">The name of the GameObject</param>
    public void ResumeSound(string sound_name){
        var music = GameObject.Find(sound_name);
        var sound = music.GetComponent<AudioSource>();
        sound.UnPause();
    }

    /// <summary>
    /// Update the skybox view
    /// </summary>
    /// <param name="skybox_name">The name of the skybox in the ressources folder</param>
    public void UpdateSkybox(string skybox_name){
        // Update Skybox
        Material skybox = Resources.Load($"materials/{skybox_name}") as Material;
        RenderSettings.skybox = skybox;
    }


    /// <summary>
    /// Remove the sound GameObject
    /// </summary>
    /// <param name="name">The name of the GameObject</param>
    public void RemoveSound(string name){
        var current_sound = GameObject.Find(name);

        if(current_sound != null){
            Destroy(current_sound);
        }
    }

    /// <summary>
    /// Reset the skybox at default value
    /// </summary>
    public void ResetSkybox(){
        var skybox = Resources.Load("materials/default") as Material;
        RenderSettings.skybox = skybox;
    }

    public void Comfort(string current_level){
        switch(current_level){
            case "arachnophobie":
                Debug.Log("Comfort arachnophobie");
                this.UpdateSkybox("comfort_arachnophobie");
                break;

            case "acrophobie":
                Debug.Log("Comfort acrophobie");
                this.UpdateSkybox("comfort_acrophobie");
                break;

            case "ophiophobie":
                Debug.Log("Comfort ophiophobie");
                this.UpdateSkybox("comfort_ophiophobie");
                break;
        }
    }

    /// <summary>
    /// Reset the setting of comfort functionnality
    /// </summary>
    public void ResetComfortSetting(GameObject ComfortSetting){
        var quit_button = ComfortSetting.GetComponent<ComfortPlayer>().quit;
        quit_button.interactable = true;
        var comfort_text = ComfortSetting.GetComponent<ComfortPlayer>().comfort_text;
        comfort_text.text = "Réconforter";
        ComfortSetting.GetComponent<ComfortPlayer>().is_active = false;
    }

    /// <summary>
    /// Create a phobie GameObject
    /// </summary>
    /// <param name="level_type">The type of the phobie</param>
    /// <param name="level_difficulty">The difficulty of the level</param>
    /// <param name="phobie_name">The name of the phobie</param>
    public void CreateGameObject(string level_type, int level_difficulty, string phobie_name){
        GameObject current_phobie = null;
        switch (level_type)
        {   
            case "arachnophobie":
                if(level_difficulty == 5){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_5") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_server";
                    current_phobie.transform.position = spiderPosition;


                    /*
                    // Chargez la texture depuis le dossier "Materials"
                    Texture spiderTexture = Resources.Load("Materials/your_spider_texture") as Texture;

                    // Récupérez le composant Renderer du GameObject
                    Renderer spiderRenderer = current_phobie.GetComponent<Renderer>();

                    // Assurez-vous que le composant Renderer existe et que la texture est chargée correctement
                    if (spiderRenderer != null && spiderTexture != null)
                    {
                        // Appliquez la texture sur le GameObject
                        spiderRenderer.material.mainTexture = spiderTexture;
                    }
                    else
                    {
                        Debug.LogWarning("La texture ou le Renderer n'ont pas été trouvés.");
                    }
                    */
                }

                if(level_difficulty == 6){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_6") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_server";
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 7){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_7") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_server";
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 8){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_8") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = "Spider_server";
                    current_phobie.transform.position = spiderPosition;
                }

                break;

            // TODO : Add acrophobie gameobject
            case "acrophobie":
                if (level_difficulty == 4)
                {
                    var balloonPrefab = Resources.Load("prefabs/acrophobie/balloon_level_4") as GameObject;
                    Vector3 balloonPosition = new Vector3(15, -20, 0);
                    current_phobie = Instantiate(balloonPrefab);
                    current_phobie.tag = "Balloon";
                    current_phobie.name = "Balloon_server";
                    current_phobie.transform.position = balloonPosition;
                    current_phobie.transform.localScale = new Vector3(100f, 100f, 100f);
                }

                if (level_difficulty == 8)
                {
                    var balloonPrefab = Resources.Load("prefabs/acrophobie/balloon_level_8") as GameObject;
                    Vector3 balloonPosition = new Vector3(15, -20, 0);
                    current_phobie = Instantiate(balloonPrefab);
                    current_phobie.tag = "Balloon";
                    current_phobie.name = "Balloon_server";
                    current_phobie.transform.position = balloonPosition;
                    current_phobie.transform.localScale = new Vector3(100f, 100f, 100f);
                }
                
                break;

            case "ophiophobie":
                if (level_difficulty == 3)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_3") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 4)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/fake_snake/snake_level_4") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 5)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/crate_snake/snake_level_5") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 6){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_6") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 7){
                    var snakePrefab = Resources.Load("prefabs/snake/real_snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 8){
                    var snakePrefab = Resources.Load("prefabs/snake/real_snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }
                break;
        }
    }

    /// <summary>
    /// Hide the phobie gameobject of the server
    /// </summary>
    /// <param name="current_phobie">The current phobie used</param>
    /// <returns></returns>
    public GameObject HideServerGameObject(GameObject current_phobie){
        current_phobie = GameObject.FindWithTag("Spider");

        if (current_phobie == null) {
            current_phobie = GameObject.FindWithTag("Snake");
        }

        if (current_phobie != null){
            current_phobie.SetActive(false);
        }

        return current_phobie;
    }

    /// <summary>
    /// Research the current hidden GameObject phobie
    /// WARNING : When a GameObject is hidden and his not accessible to through the script, it return a null value when you try to reach it
    /// So we use this code to found the current phobie with the tag associated
    /// This method is used to avoid passing an GameObject by function parameters when it's not possible
    /// This is due to the serialization of GameObject with mirror which is incompatible.
    /// This method is not recommanded and need to change in the future
    /// </summary>
    /// <returns></returns>
    public GameObject GetCurrentPhobie(){
        var current_phobie = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g=>g.CompareTag("Spider"));

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Snake"));
        }
        // TODO : Add acrophobie to phobie

        return current_phobie;
    }

    /// <summary>
    /// Show the current phobie GameObject
    /// </summary>
    public void ShowClientGameObject(){
        var current_phobie = this.GetCurrentPhobie();

        if (current_phobie != null){
            current_phobie.SetActive(true);
        }
    }

    /// <summary>
    /// Hide the current phobie GameObject
    /// </summary>
    public void HideClientGameObject(){
        var current_phobie = this.GetCurrentPhobie();

        if (current_phobie != null){
            current_phobie.SetActive(false);
        }
    }

    /// <summary>
    /// Remove GameObject of Snake and Spider
    /// </summary>
    public void RemovePhobieGameObject(){
        var current_phobie = this.GetCurrentPhobie();

        if (current_phobie != null){
            Destroy(current_phobie);
        }
    }
}
