using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject title;
    public GameObject advise;
    public GameObject advise2;
    public GameObject dialogBox2;
    public GameObject buttonMenu;
    public MyVideoPlayer myVideoPlayer;
    public UI_Assistant uiAssistant;
    public UI_Assistant2 uiAssistant2;
    public Explosion explosion;
    public PlayTheIntro playTheIntro;

    private float currentTime = 0;
    public float startMessage = 5.0f;
    public float startMessage2 = 1.0f;
    public float startTitle= 1.0f;
    public float timeTostopTitle = 4.0f;
    public float timeToAdvise= 5.1f;
    public float timeBlinkAdvise = 2.0f;
    public float timeToStopDialogBox = 2.0f;
    public float timeVideoStartDialogBox2 = 5.0f;
    public float timeVideoStartDialogBox22 = 3.0f;
    public float timeToStopDialogBox2 = 10.0f;
    public float timeStartTitle = 3.0f;
    public float timeStopTitle = 5.0f;
    public float timerAdviseBox = 3.0f;
    public bool okDialogBox2= false;
    public bool bastaAdvise = false;
    public bool isTitled = false;
    public bool isDialogBox = false;
    public bool okblinking = false;
    private int monMax=0;


    

    void Start()
    {
        monMax = 0;
        isDialogBox = false;
        okDialogBox2 =false;
        myVideoPlayer = GameObject.FindGameObjectWithTag("Television").GetComponent<MyVideoPlayer>();
        uiAssistant = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UI_Assistant>();
        uiAssistant2 = GameObject.FindGameObjectWithTag("UICanvas2").GetComponent<UI_Assistant2>();
        //buttonMenu = GameObject.FindGameObjectWithTag("ButtonMenu");
        playTheIntro = GameObject.FindGameObjectWithTag("Play").GetComponent<PlayTheIntro>();
        //buttonMenu.SetActive(true);
        title.SetActive(false);
        dialogBox.SetActive(false);
        advise.SetActive(false);
        dialogBox2.SetActive(false);
        advise2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playTheIntro.isPlaytheIntro)
        {
            Debug.Log("we can start");
            currentTime += Time.deltaTime;
            if (currentTime >= startMessage)
            {
                dialogBox.SetActive(true);
                if(myVideoPlayer.TelevisionAnimation)
                {
                    dialogBox.SetActive(false);
                    buttonMenu.SetActive(false);
                }
            }
            if(currentTime>= timeToAdvise )
            {
                if(advise!=null && !uiAssistant.firstPhrase && !okblinking)
                {
                    advise.SetActive(true);
                    
                    StartCoroutine(BlinkAdvise());  
                }
                else
                {
                    advise.SetActive(false);
                }
            }

        else
        {
            title.SetActive(false);
            dialogBox.SetActive(false);
            advise.SetActive(false);
            dialogBox2.SetActive(false);
            advise2.SetActive(false);
        }
        if(myVideoPlayer.EndTelevision && !uiAssistant2.firstPhrase2 && !isDialogBox && !okDialogBox2)
        {
            //Debug.Log("ciao end television");
            //StartCoroutine(StartDialogBox2());
            StartCoroutine(StartStartDialogBox2());
            StartCoroutine(StartTitle());
            //buttonMenu.SetActive(true);
            if(isDialogBox) //&& monMax==0)// && isDialogBox)
            {
                StartCoroutine(StopTheDialogBox2());
                
            }
            if(isTitled)
            {
                StartCoroutine(TimeStopTitle());
            }
            // else
            // {
            //     title.SetActive(false);
            //     //dialogBox2.SetActive(false);
            // }
        }

        else{
            Debug.Log("mayday problem");
            //dialogBox2.SetActive(false);
            //title.SetActive(false);
            //buttonMenu.SetActive(true);
        }

        
        if(bastaAdvise && advise2 != null)   
        {
            //Debug.Log("basta advise");
            advise2.SetActive(false);
        }
    }


    }
   
    IEnumerator BlinkAdvise()
    {
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise.SetActive(false);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise.SetActive(true);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise.SetActive(false);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise.SetActive(true);
        okblinking = true;
        
    }
    public IEnumerator StartStartDialogBox2()
    {
        yield return new WaitForSeconds(timeVideoStartDialogBox2);
        advise2.SetActive(true); 
        dialogBox2.SetActive(true);
        yield return new WaitForSeconds(timeVideoStartDialogBox22);
        isDialogBox=true;
        okDialogBox2 = true;
        //monMax+=1;
    }

    IEnumerator StopTheDialogBox2()
    {
        Debug.Log("inside stop coroutine");
        bastaAdvise=true;
        yield return new WaitForSeconds(timeToStopDialogBox2);
        dialogBox2.SetActive(false);
        isDialogBox = false;
        // title.GetComponent<Animator>().SetBool("isTitle", false);
        // title.SetActive(false);
        // monMax2+=1;
    }
    IEnumerator StartTitle()
    {
        yield return new WaitForSeconds(timeStartTitle);
        title.SetActive(true);
        title.GetComponent<Animator>().SetBool("isTitle", true);
        explosion = GameObject.FindGameObjectWithTag("Title").GetComponent<Explosion>();
        explosion.Explode();
        isTitled = true;

    }  
    IEnumerator TimeStopTitle()
    {
        yield return new WaitForSeconds(timeStopTitle);
        title.SetActive(false);
        title.GetComponent<Animator>().SetBool("isTitle", false);
        isTitled = false;

    }    
}
