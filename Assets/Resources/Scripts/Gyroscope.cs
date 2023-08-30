using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the smartphone's gyroscope functionality 
/// </summary>
public class Gyroscope : MonoBehaviour
{
    private bool gyroEnabled;
    private UnityEngine.Gyroscope gyro;
    private GameObject gyroControl;
    private Quaternion initialRotation;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        gyroEnabled = EnableGyro();

        // Ajustement de la rotation initiale pour la vue paysage
        initialRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    /// <summary>
    /// Check gyroscope availability
    /// </summary>
    /// <returns>A boolean that determines whether the gyroscope is available on the device</returns>
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

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (gyroEnabled)
        {
            Quaternion gyroQuaternion = GyroToUnity(Input.gyro.attitude);
            Quaternion calculatedRotation = initialRotation * gyroQuaternion;
            transform.rotation = calculatedRotation;
        }

    }

    /// <summary>
    /// Fix the position of the gyroscope to be synchronize with Unity
    /// </summary>
    /// <param name="q">The current attitude of the gyroscope</param>
    /// <returns>A new quaternion fixed for Unity</returns>
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
