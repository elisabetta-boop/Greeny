using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMessageStart : MonoBehaviour
{
    
    // public GameObject uiCanvas;

    // private float currentTime=0;
    // private float levelTime= 3.0f;
    
    // void Start()
    // {
    //     uiCanvas.SetActive(false);
    // }

    // void Update()
    // {
    //     currentTime += Time.deltaTime;
        
    //     // if (currentTime >= startTime)
    //     // {
    //     //     uiCanvas.SetActive(true);
    //     // }

    //     if (!uiCanvas.activeSelf)
    //     {
    //         Debug.Log("dai dai");
    //         if (currentTime > levelTime) //|| Input.GetKeyDown(KeyCode.Space))
    //         {
    //             Debug.Log("before reactivation");
    //             uiCanvas.SetActive(true);
    //         }
    //     }
    // }



    // public void StartMessage()
    // {

        
    //     if(uiCanvas !=null) //&& timer<=0)
    //     {
    //         bool isActive = uiCanvas.activeSelf;
    //         uiCanvas.SetActive(!isActive);
    //         //Debug.Log("set active en theorie");
    //     }
    // }

    
    // public float sec = 2f;
    // public MenuGame_Manager menuGame_Manager;
    // void Start()
    // {
    //     menuGame_Manager.StartCoroutine(LateCall(sec));
    // }

    // IEnumerator LateCall(float seconds)
    // {
    //     if (gameObject.activeInHierarchy)
    //         gameObject.SetActive(false);
            
        
    //     yield return new WaitForSeconds(seconds);

    //     gameObject.SetActive(true);
    //     //Do Function here...
    // }
}
