using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class killScript : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private float timer = 0;

    void Start(){
        FindObjectOfType<ParticleSystem>().trigger.AddCollider(FindObjectOfType<levelDatScript>().winCollider);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime){
            Destroy(gameObject);
        }
    }
}
