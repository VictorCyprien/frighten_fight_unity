using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages snake animation for level 8
/// </summary>
public class Snake8 : MonoBehaviour
{
    private Animator animatorComponent;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Lancement animation
        animatorComponent = GetComponent<Animator>();
        animatorComponent.Play("Slide8");
    }
}
