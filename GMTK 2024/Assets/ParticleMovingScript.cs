using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticleMovingScript : MonoBehaviour
{
    [SerializeField] Vector3 endPosition;
    [SerializeField] float speed;
    private ParticleSystem particles;
    private ParticleSystem.Particle[] modifiedParticles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        modifiedParticles= new ParticleSystem.Particle[1000];
    }

    // Update is called once per frame
    void Update()
    {
        particles.GetParticles(modifiedParticles);
        for (int i = 0; i < modifiedParticles.Count(); i++){
            modifiedParticles[i].position += (endPosition - modifiedParticles[i].position).normalized * speed * Time.deltaTime;
            print(modifiedParticles[i]);
        }
    }
}
