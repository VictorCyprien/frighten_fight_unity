using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static DataSync;

/// <summary>
/// This class is used to determine the level of difficulty and the type of phobia.
/// </summary>
public class LevelDifficulty : MonoBehaviour
{
    /// <summary>
    /// Build the name of the resource we want to load and create GameObject when needed
    /// </summary>
    /// <param name="level_type"></param>
    /// <param name="level_difficulty"></param>
    /// <returns>A string with the name of the skybox and a string with the name of the sound </returns>
    public (string, string) ChoiceLevelDifficulty(string level_type, int level_difficulty){
        string skybox_name = "";
        string sound_name = "";
        DataSync dataSync = new DataSync();
        
        switch (level_type)
        {   
            case "arachnophobie":
                sound_name = "arachnophobia_sound";
                skybox_name = "arachnophobia_view";
                dataSync.CreateGameObject(level_type, level_difficulty, "Spider_server");
                break;

            case "acrophobie":
                sound_name = "acrophobia_sound";
                skybox_name = "acrophobia_view";
                string phobie_name = null;
                if(level_difficulty == 5){
                    phobie_name = "Fence_server";
                } else {
                    phobie_name = "Balloon_server";
                }
                dataSync.CreateGameObject(level_type, level_difficulty, phobie_name);
                break;

            case "ophiophobie":
                sound_name = "ophiophobia_sound";
                skybox_name = "ophiophobia_view";
                dataSync.CreateGameObject(level_type, level_difficulty, "Snake_server");
                break;
        }
        
        switch(level_difficulty)
        {
            case 1:
                sound_name += "_easy_1";
                skybox_name += "_easy_1";
                break;

            case 2:
                sound_name += "_easy_2";
                skybox_name += "_easy_2";
                break;

            case 3:
                sound_name += "_easy_3";
                skybox_name += "_easy_3";
                break;
            
            case 4:
                sound_name += "_medium_1";
                skybox_name += "_medium_1";
                break;

            case 5:
                sound_name += "_medium_2";
                skybox_name += "_medium_2";
                break;

            case 6:
                sound_name += "_hard_1";
                skybox_name += "_hard_1";
                break;

            case 7:
                sound_name += "_hard_2";
                skybox_name += "_hard_2";
                break;

            case 8:
                sound_name += "_hard_3";
                skybox_name += "_hard_3";
                break;
        }

        return (skybox_name, sound_name);
    }
}
