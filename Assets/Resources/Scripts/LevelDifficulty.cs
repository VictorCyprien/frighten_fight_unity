using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public (string, string) ChoiceLevelDifficulty(string level_type, int level_difficulty){
        string skybox_name = "";
        string sound_name = "";
        GameObject current_phobie = null;
        
        switch (level_type)
        {   
            case "arachnophobie":
                sound_name = "arachnophobia_sound";
                skybox_name = "arachnophobia_view";

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

            case "acrophobie":
                sound_name = "acrophobie_sound";
                skybox_name = "acrophobie_view";
                break;

            case "ophiophobie":
                sound_name = "ophiophobia_sound";
                skybox_name = "ophiophobie_view";

                if(level_difficulty == 6){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_6") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 7){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_7") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

                if(level_difficulty == 8){
                    var snakePrefab = Resources.Load("prefabs/snake/snake_level_8") as GameObject;
                    Vector3 snakePosition = new Vector3(10, 1, 0);
                    current_phobie = Instantiate(snakePrefab);
                    current_phobie.tag = "Snake";
                    current_phobie.name = "Snake_server";
                    current_phobie.transform.position = snakePosition;
                }

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
