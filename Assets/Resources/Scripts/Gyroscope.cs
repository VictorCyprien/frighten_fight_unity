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
        initialRotation = Quaternion.Euler(90f, 0f, 0f);
    }

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
            Quaternion gyroQuaternion = GyroToUnity(Input.gyro.attitude);
            Quaternion calculatedRotation = initialRotation * gyroQuaternion;
            transform.rotation = calculatedRotation;
        }

    }

    // Fix gyroscope orientation
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
