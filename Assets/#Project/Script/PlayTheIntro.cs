using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheIntro : MonoBehaviour
{
    public bool isPlaytheIntro = false;

    void Start()
    {
        isPlaytheIntro = false;
    }
    public void PlayingTheIntro()
    {
        isPlaytheIntro = true;
    }
    
}
