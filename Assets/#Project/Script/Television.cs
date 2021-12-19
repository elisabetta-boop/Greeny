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
    public AudioSource boomTelevision;
    public MyVideoPlayer myVideo;
    public float timeSoundTelevision=1.5f;
    public bool isBoom = false;
    public bool restartMusic = false;

    
    

    
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
        // else if (other.CompareTag("World"))
        // {
        //     Debug.Log("is trigger the world? " + other);
        //     isBoom = true;
        //     boomTelevision.Play();
        //     StartCoroutine(RestartSoundMusic());
        // }
        }
    // IEnumerator RestartSoundMusic()
    // {
    //     yield return new WaitForSeconds(timeSoundTelevision);
    //     restartMusic = true;
    // }
   
}
