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
    //public GameObject buttonMenu;
    public GameObject buttonContinue;
    public ContinueButton continueButton;
    public Exit exit;
    public MyVideoPlayer myVideoPlayer;
    public UI_Assistant uiAssistant;
    public UI_Assistant2 uiAssistant2;
    public Explosion explosion;
    public PlayTheIntro playTheIntro;
    public TelevisionController televisionController;
    public MenuGame_Manager menuGame_Manager;

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
    public float timeStartTitle = 5.0f;
    public float timeStopTitle = 5.0f;
    public float timerAdviseBox = 3.0f;
    public bool okDialogBox2= false;
    public bool bastaAdvise = false;
    public bool isTitled = false;
    public bool isDialogBox2 = false;
    public bool okblinking = false;

    public bool isTelevisionFalling = false;

    public bool securityContinue1 = false;
    public bool securityContinue2 = false;
    public bool securityContinue3 = false;


    

    void Start()
    {
        myVideoPlayer = GameObject.FindGameObjectWithTag("Television").GetComponent<MyVideoPlayer>();
        uiAssistant = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UI_Assistant>();
        uiAssistant2 = GameObject.FindGameObjectWithTag("UICanvas2").GetComponent<UI_Assistant2>();
        //buttonMenu = GameObject.FindGameObjectWithTag("ButtonMenu");
        playTheIntro = GameObject.FindGameObjectWithTag("Play").GetComponent<PlayTheIntro>();
        continueButton = GameObject.FindGameObjectWithTag("Continue").GetComponent<ContinueButton>();
        menuGame_Manager = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
        if(menuGame_Manager.levelNow == 0)
        {
            isTelevisionFalling = false;
            securityContinue1 = false;
            securityContinue2 = false;
            securityContinue3 = false;
            
            isDialogBox2 = false;
            okDialogBox2 =false;
            //buttonMenu.SetActive(true);
            title.SetActive(false);
            dialogBox.SetActive(false);
            advise.SetActive(false);
            dialogBox2.SetActive(false);
            advise2.SetActive(false);
            buttonContinue.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(menuGame_Manager.levelNow == 0)
        {
            if(playTheIntro.isPlaytheIntro)
            {
            isTelevisionFalling = true;
            Debug.Log("we can start");
            currentTime += Time.deltaTime;
            if (currentTime >= startMessage)
            {
                dialogBox.SetActive(true);
                //ici television launch
                
                if(myVideoPlayer.TelevisionAnimation)
                {
                    dialogBox.SetActive(false);
                    advise.SetActive(false);
                    //buttonMenu.SetActive(false);
                }
            }
            else if(currentTime>= timeToAdvise)
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
            }
            else
            {
                title.SetActive(false);
                dialogBox.SetActive(false);
                advise.SetActive(false);
                //dialogBox2.SetActive(false);
                //advise2.SetActive(false);
            }

            if(myVideoPlayer.EndTelevision && !uiAssistant2.firstPhrase2)
            {
                Debug.Log("inside the start continue");
                buttonContinue.SetActive(true);
            }
            // else
            // {
            //     dialogBox2.SetActive(false);
            //     advise2.SetActive(false);
            //     title.SetActive(false);
            // }
            if(continueButton.isContinue)
            {
                StartCoroutine(StartStartDialogBox2());
                StartCoroutine(StartTitle());

                
                //buttonContinue.SetActive(false);  
            }
            if(securityContinue1)
            {
                Debug.Log("security continue 1 "+securityContinue1);
                advise2.SetActive(true); 
                dialogBox2.SetActive(true);
                //isDialogBox2 = true;
                
                StartCoroutine(StopTheDialogBox2());
                

            }
            if(securityContinue2)
            {
                Debug.Log("security continue 2 "+securityContinue2);
                title.SetActive(true);
                title.GetComponent<Animator>().SetBool("isTitle", true);
                isTitled = true;
                //explosion = GameObject.FindGameObjectWithTag("Title").GetComponent<Explosion>();
                //explosion.Explode();
                //isTitled= true;
            }
        // if(isDialogBox2)
        // {
        //     StartCoroutine(StopTheDialogBox2());
        // }
        // if(isTitled)
        // {
        //     StartCoroutine(TimeStopTitle());
        // }
        // if(okDialogBox2)
        // {
        //     dialogBox2.SetActive(false);
        //     isDialogBox2 = false;
        // }
            if(bastaAdvise)
            {
                advise2.SetActive(false);
            }

            if(isTelevisionFalling)
            {
                Debug.Log("television fallllll");
                televisionController.StartLaunchTelevision();
            }
            if(isTitled)
            {
                StartCoroutine(TimeStopTitle());
            }
            if(securityContinue3)
            {
                title.SetActive(false);
                title.GetComponent<Animator>().SetBool("isTitle", false);
                isTitled = false;
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
        securityContinue1 = true;
        
        bastaAdvise = true;

        // advise2.SetActive(true); 
        // dialogBox2.SetActive(true);
        //yield return new WaitForSeconds(timeVideoStartDialogBox22);
        //isDialogBox=true;
        //monMax+=1;
    }

    IEnumerator StopTheDialogBox2()
    {
        Debug.Log("inside stop coroutine");
        
        //bastaAdvise=true;
        yield return new WaitForSeconds(timeToStopDialogBox2);
        okDialogBox2 = true;
        
        //dialogBox2.SetActive(false);
        //isDialogBox = false;
        //okDialogBox2= false;
        // title.GetComponent<Animator>().SetBool("isTitle", false);
        // title.SetActive(false);
        // monMax2+=1;
    }
    IEnumerator StartTitle()
    {
        yield return new WaitForSeconds(timeStartTitle);
        securityContinue2 =true;
        // title.SetActive(true);
        // title.GetComponent<Animator>().SetBool("isTitle", true);
        // explosion = GameObject.FindGameObjectWithTag("Title").GetComponent<Explosion>();
        // explosion.Explode();
        //isTitled = true;

    }  
    IEnumerator TimeStopTitle()
    {
        yield return new WaitForSeconds(timeStopTitle);
        // title.SetActive(false);
        // title.GetComponent<Animator>().SetBool("isTitle", false);
        //isTitled = false;
        securityContinue3 = true;

    }    
}
