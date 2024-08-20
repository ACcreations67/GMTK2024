using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    private Vector3 playerPosition;

    void Start()
    {
        // Get the player's position and store it in the playerPosition variable
        playerPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            // Respawn the player at the stored position
            transform.position = playerPosition;
        }
    }
}