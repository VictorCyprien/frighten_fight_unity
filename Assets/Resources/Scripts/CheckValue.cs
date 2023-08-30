using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CheckValue : MonoBehaviour
{
    public Scrollbar difficulty_selector;
    public TextMeshProUGUI difficulty_text;
    public TextMeshProUGUI description_text;

    public GameObject levelChoice;

    public int minValue = 1;
    public int maxValue = 8;

    /// <summary>
    /// Build the message description of the level
    /// </summary>
    /// <param name="level_difficulty">Difficulty of the level</param>
    /// <returns>A string with the description of the level</returns>
    
    // TODO : Add new description for acrophobie
    string build_new_description(int level_difficulty, string current_level){
        string msg = "";

        switch(current_level)
        {
            case "acrophobie":
                switch(level_difficulty)
                {
                    case 1:
                        msg += "- Environnement calme\n- Un son ou une image qui peut faire pense à la phobie en question";
                        break;

                    case 2:
                        msg += "- Environnement calme\n- Une vue sur le désert, ainsi que le son du vent, va apparaître";
                        break;

                    case 3:
                        msg += "- Environnement calme\n- Une vue sur un dune dans un désert, ainsi que le son du vent, va apparaître";
                        break;

                    case 4:
                        msg += "- Environnement moins tranquille\n- Une vue depuis un chatêau, ainsi que le bruit du vent, va apparaître";
                        break;

                    case 5:
                        msg += "- Environnement moins tranquille\n- Une vue depuis les collines, ainsi que le bruit du vent, va apparaître";
                        break;

                    case 6:
                        msg += "- Environnement moins tranquille\n- Une vue depuis le balçon, ainsi que le bruit du vent, va apparaître";
                        break;

                    case 7:
                        msg += "- Environnement moins tranquille\n- Une vue depuis un immeuble, ainsi que le bruit du vent, va apparaître";
                        break;

                    case 8:
                        msg += "- Environnement hostile\n- Une vue depuis New York, ainsi que le bruit du vent, va apparaître";
                        break;
                }
                break;       

            default:
                switch(level_difficulty)
                {
                    case 1:
                        msg += "- Environnement calme\n- Un son ou une image qui peut faire pense à la phobie en question";
                        break;

                    case 2:
                        msg += "- Environnement calme\n- Un son de la phobie qui fait peur va être entendu";
                        break;

                    case 3:
                        msg += "- Environnement moins tranquille\n- Une image lointaine qui évoque la phobie apparaît";
                        break;

                    case 4:
                        msg += "- Environnement calme\n- Une image d'un jouet/élément qui ne fait pas peur mais concerne la phobie apparaît";
                        break;

                    case 5:
                        msg += "- Environnement moins tranquille\n- Image de la phobie mais présence d'éléments rassurants";
                        break;

                    case 6:
                        msg += "- Environnement moins tranquille\n- Une image en 3D de la phobie apparaît";
                        break;

                    case 7:
                        msg += "- Environnement moins tranquille\n- Une image en 3D de la phobie apparaît avec le son";
                        break;

                    case 8:
                        msg += "- Environnement hostile\n- Une image en 3D de la phobie apparaît ainsi que le son";
                        break;
                }
                break;
        }
        
        

        return msg;
    }

    /// <summary>
    /// Check the current level difficulty selected
    /// </summary>
    /// <param name="value">The value of the ScrollBar</param>
    private void OnScrollbarValueChanged(float value)
    {
        int currentStep = Mathf.RoundToInt(value * (maxValue - minValue) + minValue);
        difficulty_text.text = "Niveau " + currentStep.ToString();
        description_text.text = build_new_description(currentStep, levelChoice.tag);
        Debug.Log($"Value of Difficulty : {difficulty_text.text}");
    }

    void Start()
    {
        difficulty_selector.onValueChanged.AddListener(OnScrollbarValueChanged);
    }
}
