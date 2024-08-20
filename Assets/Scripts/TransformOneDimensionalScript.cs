using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransformOneDimensionalScript : TransformScript
{
    [SerializeField] float maxSize = 15;
    private Collider myCollider;
    private Rigidbody rb;
    private List<Collision> collisions = new List<Collision> ();
    void Start(){
        myCollider = gameObject.GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    override public void Grow(float ammount){

        if (transform.localScale.x + ammount > maxSize){
            transform.localScale = Vector3.one * maxSize;
        }
        else{
            transform.localScale += Vector3.one * ammount;
            for (int i = 0; i < collisions.Count; i++){

                float force = ammount/collisions[i].contactCount;

                for (int n = 0; n < collisions[i].contactCount; n++){
                    Vector3 point = collisions[i].contacts[n].point;
                    Vector3 totalForce = force * collisions[i].contacts[n].normal;
                    collisions[i].rigidbody.AddForceAtPosition(totalForce, point);
                    rb.AddForceAtPosition(-totalForce, point);
                }
            }
        }
    }
    override public void Shrink(float ammount){
        if (transform.localScale.x - ammount < 1f){
        transform.localScale = Vector3.one * 1f;
        }
        else{
        transform.localScale -= Vector3.one * ammount;
        }
    }

    void OnCollisionEnter(Collision other){
        collisions.Add(other);
    }
    void OnCollisionExit(Collision other)
    {
        collisions.Remove(other);
    }
}
