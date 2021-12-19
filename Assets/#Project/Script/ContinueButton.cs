using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public bool isContinue= false;
    void Start()
    {
        isContinue=false;
    }
    public void ContinueStory()
    {
        isContinue =true;
    }
}
