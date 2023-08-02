using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using System;

using static DataSync;

public class ClientSync : NetworkBehaviour
{

    DataSync dataSync;

    void Start(){
        dataSync = new DataSync();
    }

    /// <summary>
    /// Update the sound and skybox on client side
    /// </summary>
    /// <param name="sound_name">The name of the sound</param>
    /// <param name="skybox_name">The name of the skybox</param>
    [ClientRpc]
    public void UpdateSoundAndSkybox(String sound_name, String skybox_name)
    {
        Debug.Log("CLIENT !");
        dataSync.CreateSound(sound_name, "Music_client");
        dataSync.UpdateSkybox(skybox_name);
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
        switch (levelChoice)
        {   
            case "arachnophobie":
                dataSync.CreateGameObject(levelChoice, level_difficulty, "Spider_client");
                break;

            case "acrophobie":
                dataSync.CreateGameObject(levelChoice, level_difficulty, "Balloon_client");
                break;

            case "ophiophobie":
                dataSync.CreateGameObject(levelChoice, level_difficulty, "Snake_client");
                break;
        }
    }

    /// <summary>
    /// Remove current Spider or Snake GameObject for client side
    /// </summary>
    [ClientRpc]
    public void RemoveGameObject(){
        dataSync.RemovePhobieGameObject();
    }

    /// <summary>
    /// Remove sound and reset skybox to default for client side
    /// </summary>
    [ClientRpc]
    public void DeleteSoundAndSkyBox(){
        // Remove current sound
        dataSync.RemoveSound("Music_client");

        // Update SkyBox to default
        dataSync.ResetSkybox();
    }

    /// <summary>
    /// Deactivate the level to comfort the player for client side
    /// </summary>
    /// <param name="current_level">The current phobie selected</param>
    [ClientRpc]
    public void DeactivateLevel(string current_level){
        // Pause the current sound
        dataSync.PauseSound("Music_client");

        // Apply skybox for comfort player in function of current phobie
        dataSync.Comfort(current_level);

        //Hide phobie GameObject
        dataSync.HideClientGameObject();
    }

    /// <summary>
    /// Reactivate the level for client side
    /// </summary>
    /// <param name="previous_skybox">The previous skybox used for the current level</param>
    [ClientRpc]
    public void ReactivateLevel(String previous_skybox){
        // Resume current music
        dataSync.ResumeSound("Music_client");

        // Reapply previous skybox
        // Due to some technical issue, we have to apply the previous skybox here
        var previous_skybox_splited = previous_skybox.Split(" (")[0];
        RenderSettings.skybox = Resources.Load($"materials/{previous_skybox_splited}") as Material;

        //Show phobie GameObject
        dataSync.ShowClientGameObject();
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
