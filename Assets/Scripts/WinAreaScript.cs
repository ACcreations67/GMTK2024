using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAreaScript : MonoBehaviour
{
    [SerializeField] GameObject Particles;
    private bool waitingForGeg = true;
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            FindObjectOfType<TransitionManager>().nextLevel();
        }
    }
}
