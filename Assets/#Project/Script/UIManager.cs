using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject title;

    

    private float currentTime = 0;
    public float startMessage = 5.0f;
    public float startTitle= 1.0f;
    void Start()
    {
        //title = GetComponent<Animator>().gameObject;
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= startMessage)
        {
            dialogBox.SetActive(true);
        }
        if(currentTime>= startTitle)
        {
            title.GetComponent<Animator>().SetBool("isTitle", true);
            //title.SetBool("isTitle", true);
        }
    }
}
