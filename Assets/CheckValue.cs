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

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Value of Selector : {difficulty_selector.value}");
        Debug.Log($"Value of Difficulty : {difficulty_text.text}");

        difficulty_selector.onValueChanged.AddListener((value) =>
        {
            // round to int to catch floating point problems.
            int currentStep = Mathf.RoundToInt(value / (1f / (float) difficulty_selector.numberOfSteps)) + 1;
            if (value > 0.5){
                currentStep -= 1;
            }
            difficulty_text.text = "Niveau " + currentStep.ToString();
        });
    }
}
