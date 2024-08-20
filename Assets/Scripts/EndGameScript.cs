using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] float speed = .01f;
    [SerializeField] Transform playerPosition;
    bool shotsFired;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            shotsFired = true;
            playerPosition.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if (shotsFired){
            playerPosition.position += (transform.position - playerPosition.position).normalized * speed;
        }
    }
}
