using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMessageStart : MonoBehaviour
{
    public GameObject uiCanvas;

    
    public void StartMessage()
    {
        if(uiCanvas !=null)
        {
            bool isActive = uiCanvas.activeSelf;
            uiCanvas.SetActive(!isActive);
            //Debug.Log("set active en theorie");
        }
    }
}
