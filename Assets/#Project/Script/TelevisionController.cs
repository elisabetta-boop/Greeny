using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionController : MonoBehaviour
{
    public MenuGame_Manager menuGame;
    public AudioSource boomTelevision;
    public Animator TVanimator;
    public float timeToTelevision = 5f;
    public float timeSoundTelevision=1.5f;
    public float timeFallingBoom=2.0f;
    public bool isBoom=false;
    public bool okRestart= false;

    
    // Start is called before the first frame update
    void Start()
    {
        menuGame = GetComponent<MenuGame_Manager>();
        TVanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLaunchTelevision()
    {
        Debug.Log("launch Tv");
        StartCoroutine(LaunchTelevision());
    }
    IEnumerator LaunchTelevision()
    {
        yield return new WaitForSeconds(timeToTelevision);
        TVanimator.SetBool("sceneStart", true);
        isBoom = true;
        boomTelevision.Play(); 
        //StartCoroutine(RestartTheMusic());

    }
    

    // IEnumerator RestartTheMusic()
    // {
    //     yield return new WaitForSeconds(timeFallingBoom);
    //     okRestart = true;
    // }

}
