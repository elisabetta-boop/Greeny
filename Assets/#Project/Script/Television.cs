using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.Video;
using UnityEngine.UI;



public class Television : MonoBehaviour
{
    
    private Renderer colorCube;
    public UnityEvent whenLightUp;

    public MyVideoPlayer myVideo;

    
    

    
    void Start()
    {
        colorCube = GetComponent<Renderer>();
        //colorCube.material.SetColor("_Color", Color.black); 
        
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerZero"))
        {
            whenLightUp?.Invoke();
        }
        }
   
}
