using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaitingForServerCamera : MonoBehaviour
{
    /// <summary>
    /// Create a new camera object
    /// </summary>
    public void CreateCamera(){
        var cameraGameObject = new GameObject("WaitingForServerCamera");
        var camera = cameraGameObject.AddComponent<Camera>();
        camera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        camera.GetComponent<Camera>().backgroundColor = Color.grey;
    }

    /// <summary>
    /// Destroy a camera object
    /// </summary>
    public void DestroyCamera(){
        var camera = GameObject.Find("WaitingForServerCamera");
        Destroy(camera);
    }
}
