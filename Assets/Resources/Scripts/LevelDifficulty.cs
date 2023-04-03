using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public (string, string) ChoiceLevelDifficulty(string level_type, int level_difficulty){
        string skybox_name = "";
        string sound_name = "";
        
        switch (level_type)
        {   
            case "arachnophobie":
                sound_name = "jungle_sound";
                skybox_name = "jungle_view";
                break;

            case "acrophobie":
                sound_name = "acrophobie_sound";
                skybox_name = "acrophobie_view";
                break;

            case "ophiophobie":
                sound_name = "ophiophobie_sound";
                skybox_name = "ophiophobie_view";
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
                sound_name += "_medium_4";
                skybox_name += "_medium_4";
                break;

            case 5:
                sound_name += "_medium_5";
                skybox_name += "_medium_5";
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
