using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComfortPlayer : MonoBehaviour
{
    public Button comfort;
    public Button quit;
    public TextMeshProUGUI comfort_text;
    public bool is_active = false;
    public GameObject current_level;
    private GameObject current_phobie = null;
    private Material previous_skybox = null;

    // Start is called before the first frame update
    void Start()
    {
        is_active = false;
        comfort = comfort.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
		comfort.onClick.AddListener(Comfort);
    }

    /// <summary>
    /// Desactivate the level to comfort the player
    /// </summary>
    public void DeactivateLevel(){
        // Get music GameObject
        var music = GameObject.Find("Music_server");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        sound.Pause();

        // Apply default skybox in function of current phobie
        previous_skybox = RenderSettings.skybox;
        Material skybox;

        switch(current_level.tag){
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
        current_phobie = GameObject.FindWithTag("Spider");

        if (current_phobie == null) {
            current_phobie = GameObject.FindWithTag("Snake");
        }

        if (current_phobie != null){
            current_phobie.SetActive(false);
        }

        // Manage quit/comfort button
        comfort_text.text = "Reprendre";
    } 

    /// <summary>
    /// Reactivate the level when the player is comforted
    /// </summary>
    public void ReactivateLevel(){
        // Get music GameObject
        var music = GameObject.Find("Music_server");

        // Get sound from GameObject
        var sound = music.GetComponent<AudioSource>();
        sound.UnPause();

        // Reapply previous skybox
        RenderSettings.skybox = previous_skybox;
        previous_skybox = null;

        //Show phobie GameObject
        if (current_phobie != null){
            current_phobie.SetActive(true);
        }

        // Manage quit/comfort button
        comfort_text.text = "Réconforter";
    }

    /// <summary>
    /// Determines whether to pause or resume the level
    /// </summary>
    public void Comfort(){
        if (!is_active){
            Debug.Log("Comfort");
            DeactivateLevel();
            // Call comfort (CLIENT SIDE !)
            GameObject comfortPlayer = GameObject.Find("comfortPlayer");
            comfortPlayer.GetComponent<DataSync>().Comfort(is_active, RenderSettings.skybox.ToString(), current_level.tag);
            is_active = true;
        } else {
            Debug.Log("Reload");
            ReactivateLevel();
            // Call comfort (reactivate level) (CLIENT SIDE !)
            GameObject comfortPlayer = GameObject.Find("comfortPlayer");
            comfortPlayer.GetComponent<DataSync>().Comfort(is_active, RenderSettings.skybox.ToString(), current_level.tag);
            is_active = false;
        }
    }
}
