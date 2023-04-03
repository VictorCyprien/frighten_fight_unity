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

    string build_new_description(int level_difficulty){
        string msg = "";
        
        switch (level_difficulty)
        {
            case 1:
                msg += "- Environnement calme\n- Un son ou une image qui peut faire pense à la phobie en question";
                break;

            case 2:
                msg += "- Environnement calme\n- Un son de la phobie qui fait peur va être entendu";
                break;

            case 3:
                msg += "- Environnement moins tranquille\n- Une image lointaine qui invoque la phobie apparaît";
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

        return msg;
    }

    void Start()
    {
        difficulty_selector.onValueChanged.AddListener((value) =>
        {
            // round to int to catch floating point problems.
            int currentStep = Mathf.RoundToInt(value / (1f / (float) difficulty_selector.numberOfSteps)) + 1;
            if (value > 0.5){
                currentStep -= 3;
            }
            difficulty_text.text = "Niveau " + currentStep.ToString();
            description_text.text = build_new_description(currentStep);
            Debug.Log($"Value of Difficulty : {difficulty_text.text}");
        });
    }
}
