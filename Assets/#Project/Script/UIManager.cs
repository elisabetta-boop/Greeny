using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject title;
    public GameObject advise;

    

    private float currentTime = 0;
    public float startMessage = 5.0f;
    public float startTitle= 1.0f;
    
    public float timeTostopTitle = 4.0f;
    public float timeToAdvise= 5.1f;
    public float timeBlinkAdvise = 2.0f;
    public float timeToStopDialogBox = 2.0f;

    public UI_Assistant uiAssistant;

    public MyVideoPlayer myVideoPlayer;

    

    void Start()
    {
        myVideoPlayer = GameObject.FindGameObjectWithTag("Television").GetComponent<MyVideoPlayer>();
        uiAssistant = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UI_Assistant>();
        title.SetActive(true);
        dialogBox.SetActive(false);
        advise.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= startMessage)
        {
            dialogBox.SetActive(true);
            if(myVideoPlayer.TelevisionAnimation)
            {
                dialogBox.SetActive(false);
            }
            // if(uiAssistant.endFirstPhrase)
            // {
            //     StartCoroutine(EndFirstDialogBox());
            // }
        }
        if(currentTime>= startTitle)
        {
            title.GetComponent<Animator>().SetBool("isTitle", true);
            StartCoroutine(StopTitle());
        }
        if(currentTime>= timeToAdvise )
        {
            if(advise!=null && !uiAssistant.firstPhrase)
            {
                advise.SetActive(true);
                StartCoroutine(BlinkAdvise());
                
            }
            else{
                
                advise.SetActive(false);
                //Destroy(advise.gameObject);
            
            }

        }

    }
    IEnumerator StopTitle()
    {
        yield return new WaitForSeconds(timeTostopTitle);
        title.SetActive(false);
    }
    IEnumerator BlinkAdvise()
    {
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise.SetActive(false);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise.SetActive(true);
        // yield return new WaitForSeconds(timeBlinkAdvise);
        // advise.SetActive(false);
    }
    // Ienumerator EndFirstDialogBox()
    // {
    //     yield return new WaitForSeconds(timeToStopDialogBox);
    //     dialogBox.SetActive(false);
    // }
}
