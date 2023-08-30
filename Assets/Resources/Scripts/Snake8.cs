using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake8 : MonoBehaviour
{

    private Animator animatorComponent;

    // Start is called before the first frame update
    void Start()
    {
        // Lancement animation
        animatorComponent = GetComponent<Animator>();
        animatorComponent.Play("Slide8");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
