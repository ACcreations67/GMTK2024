using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class planeRotateScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= quaternion.AxisAngle(Vector3.forward, speed * Time.deltaTime);
        transform.rotation = quaternion.LookRotation((transform.position - playerTransform.position).normalized, transform.up);
    }
}
