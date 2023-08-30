using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages snake animation for level 7
/// </summary>
public class Snake7 : MonoBehaviour
{
    public float radius = 100000000f;          // Le rayon du cercle
    public float speed = 1000f;          // La vitesse de déplacement circulaire
    public float rotationOffset = 90f;  // L'angle de décalage pour la rotation

    private float angle = 0f;           // L'angle actuel du mouvement circulaire
    private Vector3 centerPosition;     // La position du centre du cercle
    private Animator animatorComponent;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Lancement animation
        animatorComponent = GetComponent<Animator>();
        animatorComponent.Play("Slide7");

         // Assurez-vous que l'objet est au centre de la skybox au démarrage
        centerPosition = Vector3.zero;
        transform.position = centerPosition + Vector3.right * radius;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Mise à jour de l'angle en fonction du temps écoulé depuis le début de la scène
        angle -= speed / 4 * Time.deltaTime;

        // Calcul de la nouvelle position circulaire
        float xPos = centerPosition.x + Mathf.Cos(angle) * radius;
        float zPos = centerPosition.z + Mathf.Sin(angle) * radius;

        // Mise à jour de la position de l'objet
        Vector3 newPosition = new Vector3(xPos, centerPosition.y, zPos);
        transform.position = newPosition;

        // Rotation de l'objet pour qu'il regarde vers sa position future avec le décalage
        Vector3 lookDirection = newPosition - centerPosition;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection) * Quaternion.Euler(0f, rotationOffset, 0f);
        transform.rotation = targetRotation;
    }
}
