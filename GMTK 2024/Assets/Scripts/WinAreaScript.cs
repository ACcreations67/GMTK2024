using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAreaScript : MonoBehaviour
{
    [SerializeField] GameObject Particles;
    private bool waitingForGeg = true;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Geg")){
            Instantiate(Particles, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            waitingForGeg = false;
        }
        else if (!waitingForGeg && other.CompareTag("Player")){
            FindObjectOfType<TransitionManager>().nextLevel();
        }
    }
}
