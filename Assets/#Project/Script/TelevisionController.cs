using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionController : MonoBehaviour
{
    public MenuGame_Manager menuGame;
    public Animator TVanimator;
    public float timeToTelevision = 5f;
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
        //Debug.Log("launch Tv");
        StartCoroutine(LaunchTelevision());
    }
    IEnumerator LaunchTelevision()
    {
        yield return new WaitForSeconds(timeToTelevision);
        TVanimator.SetBool("sceneStart", true);
    }
}
