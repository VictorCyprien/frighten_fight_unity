using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPathBounce : MonoBehaviour
{
    public float speed = 2f;                // La vitesse de déplacement
    public float boundingBoxSize = 5f;      // Taille de la zone rectangulaire

    private Vector3 spawnPosition;          // Position d'apparition de l'araignée
    private Vector3 targetPosition;         // Prochaine position cible
    private Vector3 moveDirection;          // Direction de mouvement
    private Animator animatorComponent;

    private void Start()
    {
        // Mémorisation de la position d'apparition
        spawnPosition = transform.position;

        // Initialisation de la direction de mouvement avec un angle aléatoire
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.right;

        // Calcul de la première position cible
        CalculateNextTargetPosition();

        // Lancement de l'animation
        animatorComponent = GetComponent<Animator>();
        animatorComponent.Play("Walk");
    }

    private void Update()
    {
        // Calcul du déplacement
        Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

        // Vérification des rebonds sur les bords de la zone rectangulaire
        if (newPosition.x > spawnPosition.x + boundingBoxSize || newPosition.x < spawnPosition.x - boundingBoxSize)
        {
            moveDirection.x *= -1; // Inversion de la direction horizontale
            CalculateNextTargetPosition();
        }

        if (newPosition.z > spawnPosition.z + boundingBoxSize || newPosition.z < spawnPosition.z - boundingBoxSize)
        {
            moveDirection.z *= -1; // Inversion de la direction verticale
            CalculateNextTargetPosition();
        }

        // Mise à jour de la position
        transform.position = newPosition;

        // Mise à jour de la rotation pour faire face à la direction opposée du mouvement
        Vector3 lookDirection = -moveDirection;
        if (lookDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = newRotation;
        }
    }

    // Calcule la prochaine position cible
    private void CalculateNextTargetPosition()
    {
        targetPosition = spawnPosition + moveDirection * boundingBoxSize * 2; // Double de la taille pour atteindre le bord opposé
        moveDirection = (targetPosition - transform.position).normalized;
    }
}
