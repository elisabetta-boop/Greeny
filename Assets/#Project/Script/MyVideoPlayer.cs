using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class MyVideoPlayer : MonoBehaviour
{
    // public GameObject mainCamera;
    // public GameObject televisionCamera;
    public Camera mainCamera;
    public Camera televisionCamera;
    public VideoPlayer videoPlayer;
    
    public float timeVideoStart =5;

    public bool TelevisionAnimation = false;
    public CameraTelevision cameraTelevision;
    public PlayerZeroTransformation zeroPlayer;
    public bool startVideo = false;
    
    public bool EndTelevision = false;
    
    
    void Awake() 
    {
        // mainCamera = GameObject.Find("Main Camera");
        videoPlayer = GetComponent<VideoPlayer>();
        // zeroPlayer = GetComponent<PlayerZeroTransformation>();
    }
    void Start()
    {
        mainCamera.enabled = true;
        televisionCamera.enabled =false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            cameraTelevision.cameraAnimator.SetBool("TelevisionAnimation", false);
            EndTelevision = true;
            BackToMainCamera();

            
            
            
            //zeroPlayer.ZeroTrasform();
            Debug.Log("the time is finish and trasforming "+zeroPlayer.isTransforming);
            
        }
        // if(startVideo)
        // {
        //     zeroPlayer.isTransforming = true;
        //     Debug.Log(zeroPlayer.isTransforming);
                            
        // }
    }
    public void playMyVideoTelevision()
    {
        
        TelevisionAnimation = true;
        mainCamera.enabled = false;
        televisionCamera.enabled = true;
        
        StartCoroutine(coroutinePlayVideo());
        cameraTelevision.cameraAnimator.SetBool("TelevisionAnimation", true);
        // green lights on maybe coroutine
    }
    IEnumerator coroutinePlayVideo()
    {
        yield return new WaitForSeconds(timeVideoStart); // maybe less than 5 kind 4.5
        startVideo = true;
        Debug.Log("time to start" + timeVideoStart);
        Debug.Log("video length " + videoPlayer.length);
        videoPlayer.Play();
    }

    void BackToMainCamera()
    {
        cameraTelevision.cameraAnimator.SetBool("EndTelevision", true);
        //Debug.Log("bau bau bau");
    }

    
    
}
