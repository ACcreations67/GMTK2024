using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    Transform player;
    void Start()
    {
        player = FindObjectOfType<FirstPersonMovement>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (player.position.y < 0 || Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
