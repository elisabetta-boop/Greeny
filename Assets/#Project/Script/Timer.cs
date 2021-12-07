using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private float timer = 0;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public float timeToDisplay;
    public Text timeText;
    public bool isBlinking = false;
    public Blink blink;
    
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        blink = GetComponent<Blink>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        TheTimer();
        TheCountDown();
        if(isBlinking)
        {
            //Debug.Log("start blinking");
            blink.StartBlinking(); 
        }
    }
    public void TheTimer()
    {
        //Debug.Log("timer");
        if (timer <2.0)
        {
            //Debug.Log("less than 2 seconds after start ");
        }   
    }
    public void TheCountDown()
    {
        timeRemaining -= Time.deltaTime;
        // Debug.Log(timeRemaining);
        // if (timeRemaining<2.0)
        // {
        //     Debug.Log("attention less than 2 seconds");
        // }
        // else
        // {
        //     Debug.Log("time has run out");
        // }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeToDisplay = timeRemaining;
                timeRemaining -= Time.deltaTime;
                //DisplayTime(timeRemaining);
                DisplayTime(timeToDisplay);

                if(timeRemaining <= 280.0f)
                {
                    //Debug.Log("blinking timer");
                    isBlinking = true;
                    //Debug.Log("isblinking "+isBlinking);
                }  
            }
            else
            {
                //Debug.Log("Time has run out!");
                
                timeRemaining =0;
                timerIsRunning = false;
            }
    }
    }
    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay <0)
        {
            timeToDisplay=0;
        }
        // else if(timeToDisplay>0)
        // {
        //     timeToDisplay += 1;
        // }
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = timeToDisplay %1*1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds,milliSeconds);
    }  
}
