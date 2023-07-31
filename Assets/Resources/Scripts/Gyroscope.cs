using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    private bool gyroEnabled;
    private UnityEngine.Gyroscope gyro;
    private GameObject gyroControl;
    private Quaternion initialRotation;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        gyroEnabled = EnableGyro();

        // Ajustement de la rotation initiale pour la vue paysage
        initialRotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    /// <summary>
    /// Check if the system support the Gyroscope and apply some settings
    /// </summary>
    /// <returns>A Boolean value who indicate if the system support the gyroscope</returns>
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            // Enable gyro
            gyro = Input.gyro;
            gyro.enabled = true;

            // Create new Gyro Object
            gyroControl = new GameObject("Gyro Control");
            gyroControl.transform.position = transform.position;
            transform.SetParent(gyroControl.transform);

            return true;
        }

        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            Quaternion gyroAttitude = gyro.attitude;
            Quaternion targetRotation = initialRotation * gyroAttitude;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
