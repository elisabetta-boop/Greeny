using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public bool isStop = false;
    void Start()
    {
        isStop=false;
    }
    public void StopStory()
    {
        isStop =true;
    }
}
