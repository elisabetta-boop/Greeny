using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Billboard : MonoBehaviour
{
    public Transform cam;

    
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("3rdCam").GetComponent<Transform>();
    }
    
    
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
