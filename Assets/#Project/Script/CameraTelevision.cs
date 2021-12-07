using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTelevision : MonoBehaviour
{
    public Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
