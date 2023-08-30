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
        // TODO : We need to fix the position for the smartphone and PC
        // There is a small difference for the distance 
        switch (level_type)
        {   
            case "arachnophobie":

                if(level_difficulty == 1){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_1") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 2){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_1") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 3){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_1") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 4){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_1") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 5){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_5") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
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
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 7){
                    var spiderPrefab = Resources.Load("prefabs/spider/spider_level_7") as GameObject;
                    Vector3 spiderPosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition;
                }

                if(level_difficulty == 8){
                    var spiderPrefab1 = Resources.Load("prefabs/spider/spider_level_8") as GameObject;
                    Vector3 spiderPosition1 = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(spiderPrefab1);
                    current_phobie.tag = "Spider";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = spiderPosition1;                
                }

                break;

            case "acrophobie":
                if (level_difficulty == 4)
                {
                    var balloonPrefab = Resources.Load("prefabs/acrophobie/balloon_level_4") as GameObject;
                    Vector3 balloonPosition = new Vector3(15, -22, 0);
                    current_phobie = Instantiate(balloonPrefab);
                    current_phobie.tag = "Balloon";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = balloonPosition;
                    current_phobie.transform.localScale = new Vector3(105f, 105f, 105f);
                }

                if (level_difficulty == 5)
                {
                    var fencePrefab = Resources.Load("prefabs/acrophobie/fence_level_5") as GameObject;
                    Vector3 fencePosition = new Vector3(-124, -101, -115);
                    current_phobie = Instantiate(fencePrefab);
                    current_phobie.tag = "Fence";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = fencePosition;
                    current_phobie.transform.localScale = new Vector3(100f, 100f, 100f);
                }

                if (level_difficulty == 8)
                {
                    var balloonPrefab = Resources.Load("prefabs/acrophobie/balloon_level_8") as GameObject;
                    Vector3 balloonPosition = new Vector3(15, -22, 0);
                    current_phobie = Instantiate(balloonPrefab);
                    current_phobie.tag = "Balloon";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = balloonPosition;
                    current_phobie.transform.localScale = new Vector3(105f, 105f, 105f);
                }
                
                break;

            case "ophiophobie":
                if (level_difficulty == 3)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_3") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 4)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/fake_snake/snake_level_4") as GameObject;
                    Vector3 snakePosition = new Vector3(15, -5, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = snakePosition;
                    current_phobie.transform.Rotate(0, 1, 180);
                    current_phobie.transform.localScale = new Vector3(5, 5, 5);
                }

                if (level_difficulty == 5)
                {
                    var snakePrefab = Resources.Load("prefabs/snake/crate_snake/snake_level_5") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = snakePosition;
                }

                if (level_difficulty == 6){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_6") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 7){
                    var snakePrefab = Resources.Load("prefabs/snake/real_snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 8){
                    var snakePrefab = Resources.Load("prefabs/snake/real_snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = phobie_name;
                    current_phobie.transform.position = snakePosition;
                }
                break;
        }
    }

    /// <summary>
    /// Hide the phobie gameobject of the server
    /// </summary>
    /// <param name="current_phobie">The current phobie used</param>
    /// <returns>A GameObject with the current phobie</returns>
    public GameObject HideServerGameObject(GameObject current_phobie){
        current_phobie = GameObject.FindWithTag("Spider");

        if (current_phobie == null) {
            current_phobie = GameObject.FindWithTag("Snake");
        }

        if (current_phobie == null) {
            current_phobie = GameObject.FindWithTag("Balloon");
        }

        if (current_phobie == null) {
            current_phobie = GameObject.FindWithTag("Fence");
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
    /// <returns>A GameObject with the current phobie</returns>
    public GameObject GetCurrentPhobie(){
        var current_phobie = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g=>g.CompareTag("Spider"));

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Snake"));
        }

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Balloon"));
        }

        if (current_phobie == null) {
            current_phobie = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g=>g.CompareTag("Fence"));
        }

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
