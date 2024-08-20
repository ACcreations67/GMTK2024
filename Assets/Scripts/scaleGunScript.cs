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
    private float visualTimer;
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

    [SerializeField] float visualDurration;

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
        else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            growing = Input.GetMouseButtonDown(0);
            isShooting = true;
            lineRenderer.enabled = true;
            visualTimer = 0;
            timer = 0;
        }
        if (visualTimer > visualDurration){
            lineRenderer.enabled = false;
        }
        else if (visualTimer <= visualDurration){
            visualTimer += Time.deltaTime;

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, Mathf.Infinity, transformableMask)){
                lineRenderer.SetPositions(new Vector3[2] {rayStartPos.position, hit.point});
                TransformScript transformScript = hit.transform.gameObject.GetComponent<TransformScript>();
                if (transformScript != null && isShooting){
                    if (growing){
                        transformScript.Grow(transformSpeed);
                        isShooting = false;
                    }
                    else{
                        transformScript.Shrink(transformSpeed);
                        isShooting = false;
                    }
                }
            }
            else{
                lineRenderer.SetPositions(new Vector3[2] {rayStartPos.position, cameraTransform.position + cameraTransform.forward * visualLength});
            }  
        }
    }
}
