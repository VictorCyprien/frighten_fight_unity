using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static DataSync;

public class ComfortPlayer : MonoBehaviour
{
    public Button comfort;
    public Button quit;
    public TextMeshProUGUI comfort_text;
    public bool is_active = false;
    public GameObject current_level;
    private GameObject current_phobie = null;
    private Material previous_skybox = null;
    private DataSync dataSync;

    // Start is called before the first frame update
    void Start()
    {
        dataSync = new DataSync();
        is_active = false;
        comfort = comfort.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
		comfort.onClick.AddListener(Comfort);
    }

    /// <summary>
    /// Desactivate the level to comfort the player
    /// </summary>
    public void DeactivateLevel(){
        // Pause the music
        dataSync.PauseSound("Music_server");

        // Apply default skybox in function of current phobie
        previous_skybox = RenderSettings.skybox;
        switch(current_level.tag){
            case "arachnophobie":
                Debug.Log("Comfort arachnophobie");
                dataSync.UpdateSkybox("comfort_arachnophobie");
                break;

            case "acrophobie":
                Debug.Log("Comfort acrophobie");
                dataSync.UpdateSkybox("comfort_acrophobie");
                break;

            case "ophiophobie":
                Debug.Log("Comfort ophiophobie");
                dataSync.UpdateSkybox("comfort_ophiophobie");
                break;

            default:
                Debug.Log("This should not arrive...");
                dataSync.UpdateSkybox("materials/default");
                break;
        }

        //Hide phobie GameObject
        // TODO : Add acrophobie gameobject for later
        current_phobie = dataSync.HideServerGameObject(current_phobie);

        // Manage quit/comfort button
        comfort_text.text = "Reprendre";
    } 

    /// <summary>
    /// Reactivate the level when the player is comforted
    /// </summary>
    public void ReactivateLevel(){
        // Resume music GameObject
        dataSync.ResumeSound("Music_server");

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
            comfortPlayer.GetComponent<ClientSync>().Comfort(is_active, RenderSettings.skybox.ToString(), current_level.tag);
            is_active = true;
        } else {
            Debug.Log("Reload");
            ReactivateLevel();
            // Call comfort (reactivate level) (CLIENT SIDE !)
            GameObject comfortPlayer = GameObject.Find("comfortPlayer");
            comfortPlayer.GetComponent<ClientSync>().Comfort(is_active, RenderSettings.skybox.ToString(), current_level.tag);
            is_active = false;
        }
    }
}
