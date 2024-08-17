using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAreaScript : MonoBehaviour
{
    private bool waitingForGeg = true;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Geg")){
            Destroy(other.gameObject);
            waitingForGeg = false;
        }
        else if (!waitingForGeg && other.CompareTag("Player")){
            FindObjectOfType<TransitionManager>().nextLevel();
        }
    }
}
