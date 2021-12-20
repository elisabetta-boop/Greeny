using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject title;
    public GameObject gameOverGameObjectTitle;
    public GameOverTitle gameOverTitle;
    
    public GameObject advise;
    public GameObject advise2;
    public GameObject dialogBox2;
    //public GameObject buttonMenu;
    public GameObject buttonContinue;
    public GameObject buttonStop;
    public GameObject panelAdviseMenuTwo;
    public PanelAdios panelAdios;
    public GameObject panelGameObjectGrizzys;
    public PanelAdios panelAdiosGrizzys;
    public ContinueButton continueButton;
    public StopButton stopButton;
    public Exit exit;
    public MyVideoPlayer myVideoPlayer;
    public UI_Assistant uiAssistant;
    public UI_Assistant2 uiAssistant2;
    public Explosion explosion;
    public PlayTheIntro playTheIntro;
    public TelevisionController televisionController;
    public MenuGame_Manager menuGame_Manager;
    public GameObject PanelTuto;
    public PanelAdios panelAdios2;
    public Explosion explosionGreeny;

    private float currentTime = 0;
    public float startMessage = 3.0f;
    public float startMessage2 = 1.0f;
    public float startTitle= 1.0f;
    public float timeTostopTitle = 4.0f;
    public float timeToAdvise= 4.1f;
    public float timeBlinkAdvise = 2.0f;
    public float timeToStopDialogBox = 2.0f;
    public float timeVideoStartDialogBox2 = 2.0f;
    public float timeVideoStartDialogBox22 = 3.0f;
    public float timeToStopDialogBox2 = 10.0f;
    public float timeStartTitle = 5.0f;
    public float timeStopTitle = 5.0f;
    public float timerAdviseBox = 3.0f;
    public float timeToStartContinueSafe = 20.0f;
    public float timeToStartContinueSafeZero = 0.0f;
    public float timeStopPanelTuto =2.0f;
    public bool okDialogBox2= false;
    public bool bastaAdvise = false;
    public bool isTitled = false;
    public bool isDialogBox2 = false;
    public bool okblinking = false;

    public bool isTelevisionFalling = false;
    public bool isGameOver = false;

    public bool securityContinue1 = false;
    public bool securityContinue2 = false;
    public bool securityContinue3 = false;
    public bool securityContinue4 = false;
    public bool isOkPanelTuto =false;

    public Animator gameOverAnimator;
    
    private void Awake()
    {
        menuGame_Manager = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
        if(menuGame_Manager.levelNow == 0)
        {
            myVideoPlayer = GameObject.FindGameObjectWithTag("Television").GetComponent<MyVideoPlayer>();

        }
        
    }

    

    private void Start()
    {
        if(menuGame_Manager.levelNow == 0)
        {
            uiAssistant = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UI_Assistant>();
            uiAssistant2 = GameObject.FindGameObjectWithTag("UICanvas2").GetComponent<UI_Assistant2>();
            //buttonMenu = GameObject.FindGameObjectWithTag("ButtonMenu");
            playTheIntro = GameObject.FindGameObjectWithTag("Play").GetComponent<PlayTheIntro>();
            continueButton = GameObject.FindGameObjectWithTag("Continue").GetComponent<ContinueButton>();
            
            isTelevisionFalling = false;
            securityContinue1 = false;
            securityContinue2 = false;
            securityContinue3 = false;
            
            isDialogBox2 = false;
            okDialogBox2 =false;
            //buttonMenu.SetActive(true);
            title.SetActive(false);
            //dialogBox.SetActive(false);
            advise.SetActive(false);
            dialogBox2.SetActive(false);
            advise2.SetActive(false);
            buttonContinue.SetActive(false);
            PanelTuto.SetActive(false);
        }
        if(menuGame_Manager.levelNow == 1)
        {
            panelGameObjectGrizzys.SetActive(true);
            panelAdiosGrizzys = GameObject.FindGameObjectWithTag("PanelAdviseMenuZero").GetComponent<PanelAdios>();
        }
        if(menuGame_Manager.levelNow == 2)
        {
            panelAdviseMenuTwo.SetActive(true);
            panelAdios = GameObject.FindGameObjectWithTag("PanelGrizzys").GetComponent<PanelAdios>();
        }
        if(menuGame_Manager.levelNow == 10)
        {
            gameOverTitle = GameObject.FindGameObjectWithTag("GameOverTitle").GetComponent<GameOverTitle>();
            isGameOver = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(menuGame_Manager.levelNow == 0)
        {
            if(playTheIntro.isPlaytheIntro)// && isTelevisionFalling != null)
            {
                //explosionGreeny = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<Explosion>();
                MenuZeroConditionsIntro();

                if(continueButton.isContinue)
                {
                    dialogBox.SetActive(false);
                    dialogBox2.SetActive(true);
                    //MenuZeroContinueConditions();
                    StartCoroutine(StartStartDialogBox2());
                    StartCoroutine(StartTitle());
                }
            }

        
            if(securityContinue1)
            {
                Debug.Log("security continue 1 "+securityContinue1);
                advise2.SetActive(true);
                StartCoroutine(BlinkAdvise2()); 
                //dialogBox2.SetActive(true);
                //isDialogBox2 = true;
                
                StartCoroutine(StopTheDialogBox2());
            }
            
            else if(securityContinue2)
            {
                Debug.Log("security continue 2 "+securityContinue2);
                title.SetActive(true);
                title.GetComponent<Animator>().SetBool("isTitle", true);
                StartCoroutine(TimeStopTitle());
                isTitled = true;
                explosion = GameObject.FindGameObjectWithTag("Title").GetComponent<Explosion>();
                explosion.Explode();
            }
            else if(isTitled)
            {
                StartCoroutine(TimeStopTitle());
            }     
            else if(bastaAdvise)
            {
                advise2.SetActive(false);
                //PanelTuto.SetActive(true);
            }   
        
            else if(securityContinue3)
            {
                title.SetActive(false);
                title.GetComponent<Animator>().SetBool("isTitle", false);
                //isTitled = false;
            }
                        
                    
            else if(stopButton.isStop)
            {
                title.SetActive(false);
                dialogBox.SetActive(false);
                advise.SetActive(false);
                dialogBox2.SetActive(false);
                advise2.SetActive(false);
                //PanelTuto.SetActive(false);
            }
            else if(panelAdios2.isPanelOk && isTitled)
            {
                PanelTuto.SetActive(true);
            }

        
            else
            {
                title.SetActive(false);
                //dialogBox.SetActive(false);
                advise.SetActive(false);
                dialogBox2.SetActive(false);
                advise2.SetActive(false);
                PanelTuto.SetActive(false);
            }
        }
    if(menuGame_Manager.levelNow == 1)
    {
        if(!panelAdiosGrizzys.isPanelOk)
        {
            panelGameObjectGrizzys.SetActive(true);
        }
        // else{
        //     panelGameObjectGrizzys.SetActive(false);
        // }
        
        
    }
    if(menuGame_Manager.levelNow == 2)
    {
        if(!panelAdios.isPanelOk)
        {
            panelAdviseMenuTwo.SetActive(true);
        }
        
        
    }
               

        
    if(menuGame_Manager.levelNow == 10)
    {
        if(gameOverTitle.okAnim)
        {
            Debug.Log("ok stop game over anim");
            StartCoroutine(TimeStopGameOverTitle());
            
        }
        if(securityContinue4)
        {
            gameOverGameObjectTitle.SetActive(false);
        }
        }
        
    }
    
    public void MenuZeroConditionsIntro()
    {
        isTelevisionFalling = true;
        Debug.Log("television fallllll");
        televisionController.StartLaunchTelevision();
        Debug.Log("we can start");
                
        currentTime += Time.deltaTime;
        if (currentTime >= startMessage)// && !myVideoPlayer.TelevisionAnimation)
        {
            dialogBox.SetActive(true);
            buttonContinue.SetActive(true);
     
            
        
        }
        
        else if(currentTime>= timeToAdvise)
        {
            if(advise!=null && !uiAssistant.firstPhrase && !okblinking )//&& !myVideoPlayer.TelevisionAnimation)
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
    // public void MenuZeroContinueConditions()
    // {
    //     //dialogBox2.SetActive(true);
    //     StartCoroutine(StartStartDialogBox2());
    //     StartCoroutine(StartTitle());
        
    //     //buttonContinue.SetActive(false);  
        
    // }
  
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
    IEnumerator BlinkAdvise2()
    {
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise2.SetActive(false);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise2.SetActive(true);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise2.SetActive(false);
        yield return new WaitForSeconds(timeBlinkAdvise);
        advise2.SetActive(true);
        //okblinking = true;  
    }
    public IEnumerator StartStartDialogBox2()
    {
        yield return new WaitForSeconds(timeVideoStartDialogBox2);
        securityContinue1 = true;
        
        bastaAdvise = true;

        // advise2.SetActive(true); 
        //dialogBox2.SetActive(true);
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
    IEnumerator TimeStopGameOverTitle()
    {
        yield return new WaitForSeconds(timeStopTitle);
        securityContinue4 = true;

    }
    IEnumerator StopPanelTuto()
    {
        yield return new WaitForSeconds(timeStopPanelTuto);

        isOkPanelTuto= true;
    }
}
