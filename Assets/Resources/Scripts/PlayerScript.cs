using Mirror;
using UnityEngine;
using System;

/// <summary>
/// This class manages the player
/// </summary>
public class PlayerScript : NetworkBehaviour
{

    /// <summary>
    /// Set a new position for the player's camera
    /// </summary>
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 4.5f, 0);
    }


    /// <summary>
    /// Update is called once per frame (For the debug, it's simulate the gyroscope control)
    /// </summary>
    void Update()
    {
        if (!isLocalPlayer) { return; }

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 105.0f;

        transform.Rotate(0, moveX, 0);
        transform.Rotate(moveY, 0, 0);
    }
}
