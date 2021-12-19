using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheIntro : MonoBehaviour
{
    public PlayTheIntro playTheIntro;

    void Start()
    {
        playTheIntro = GameObject.FindGameObjectWithTag("Play").GetComponent<PlayTheIntro>();
    }
    void Update()
    {

    }
    public void StopTheIntroStop()
    {
        if(playTheIntro.isPlaytheIntro)
        {
            playTheIntro.isPlaytheIntro = false;
        }
    }
}
