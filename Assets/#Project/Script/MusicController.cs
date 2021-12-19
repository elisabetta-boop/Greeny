using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public MyVideoPlayer myVideoPlayer;
    public AudioSource myAudioSource;
    public AudioSource televisionFallingBoom;
    public TelevisionController televisionController;
    
    public Television television;
    public bool isPlaying=false;
    public bool isChangingMusique=false;
    public float timeFallingBoom = 2.0f;
    public float timeSTopAfterFallingBoom= 2.0f;
    public bool isRestarted = false;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        isPlaying =true;
        isChangingMusique = false;
        myVideoPlayer = GameObject.FindGameObjectWithTag("Television").GetComponent<MyVideoPlayer>();
        televisionFallingBoom = GameObject.FindGameObjectWithTag("televisionAudio").GetComponent<AudioSource>();
        televisionController = GameObject.FindGameObjectWithTag("televisionAudio").GetComponent<TelevisionController>();
        television = GameObject.Find("TV_low").GetComponent<Television>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(myVideoPlayer.TelevisionAnimation)
        {
            Debug.Log("ciao musica");
            myAudioSource.Stop();
        }
        if (myVideoPlayer.EndTelevision)
        {
            myAudioSource.Play();
        }
        // if(televisionController.isBoom)
        // {
        //     myAudioSource.Stop();
        // }
        // if(televisionController.okRestart)
        // {
        //     myAudioSource.Play();
        // }
        
    }
        // IEnumerator StopTheMusic()
        // {
        //     yield return new WaitForSeconds(timeFallingBoom);
        //     myAudioSource.Stop();
        //     televisionFallingBoom.Play();
        //     isRestarted=true;
        // }
        // IEnumerator RestartTheMusic()
        // {
        //     //televisionFallingBoom.Play();
        //     yield return new WaitForSeconds(timeSTopAfterFallingBoom);
        //     myAudioSource.Play();
        // } 

}
