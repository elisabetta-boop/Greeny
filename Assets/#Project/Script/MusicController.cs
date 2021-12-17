using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public MyVideoPlayer myVideoPlayer;
    public AudioSource myAudioSource;
    public bool isPlaying=false;
    public bool isChangingMusique=false;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        isPlaying =true;
        isChangingMusique = false;
        myVideoPlayer = GameObject.FindGameObjectWithTag("Television").GetComponent<MyVideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(myVideoPlayer.TelevisionAnimation)
        {
            Debug.Log("ciao musica");
            myAudioSource.Stop();
        }
        else if (myVideoPlayer.EndTelevision)
        {
            myAudioSource.Play();
        }
        // if(isPlaying && !isChangingMusique)
        // {
        //     myAudioSource.Play();
        // }
        // else if(!isPlaying && isChangingMusique)
        // {
        //     myAudioSource.Stop();
        // }

        // if (myVideoPlayer.startVideo)
        // {
        //     //myAudioSource.Stop();
        //     Debug.Log("come mai");
        //     isChangingMusique = true;
        //     isPlaying = false;
        // }
        // if (myVideoPlayer.EndTelevision)
        // {
        //     //myAudioSource.Play();
        //     isChangingMusique= false;
        //     isPlaying = true;
        // }
    }
}
