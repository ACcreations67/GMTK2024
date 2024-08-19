using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleGunScript : MonoBehaviour
{
    [Header("Shoot Info")]
    [SerializeField] Transform cameraTransform;
    [SerializeField] float delay;
    [SerializeField] Transform rayStartPos;
    private float timer;
    [Header("Transform Peramaters")]
    [SerializeField] float transformSpeed;

    private bool growing;
    [SerializeField] LayerMask transformableMask;
    [Header("Pickup Peramaters")]
    [SerializeField] float maximumSize;
    [SerializeField] float range;

    [Header("Ray Peramaters")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float visualLength;

    private bool isHolding;
    private bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= delay){
            timer += Time.deltaTime;
        }
        if (timer > delay && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))){
            growing = Input.GetMouseButtonDown(0);
            print("On");
            isShooting = true;
            lineRenderer.enabled = true;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)){
            print("off");
            isShooting = false;
            lineRenderer.enabled = false;
        }
        if (isShooting){
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, Mathf.Infinity, transformableMask)){
                lineRenderer.SetPositions(new Vector3[2] {rayStartPos.position, hit.point});
                TransformScript transformScript = hit.transform.gameObject.GetComponent<TransformScript>();
                if (transformScript != null){
                    if (growing){
                        transformScript.Grow(transformSpeed * Time.deltaTime);
                    }
                    else{
                        transformScript.Shrink(transformSpeed * Time.deltaTime);
                    }
                }
            }
            else{
                lineRenderer.SetPositions(new Vector3[2] {rayStartPos.position, cameraTransform.position + cameraTransform.forward * visualLength});
            }            
        }
    }
}
