
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistant2 : MonoBehaviour {

    private Text messageText2;
    
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private Animator animator;
    public GameObject uiCanvas;
    public bool firstPhrase2= false;
    public bool endFirstPhrase= false;

    private void Awake() {

        firstPhrase2 = false;
        messageText2 = transform.Find("Messages2").Find("messageText2").GetComponent<Text>();
        

        talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();

        transform.Find("Messages2").GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive()) {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            } else {
                // if(!firstPhrase)
                // {
                firstPhrase2 = true;
                string[] messageArray = new string[] {
                    "ooooooooooohhhh....  as if by magic he transformed into ... Greeny! ... vibrant with new energy, his mission now is to color the whole world green ... if you want to help him enter the door to find out what happens ...               ",
                };
                string message = messageArray[Random.Range(0, messageArray.Length)];
                StartTalkingSound();
                textWriterSingle = TextWriter.AddWriter_Static(messageText2, message, .05f, true, true, StopTalkingSound);
                
                //}


            }
            
        };
    }
    // private void StartUIAssistant()
    // {
    //     uiCanvas.SetActive(true);
    // }
    private void StartTalkingSound() {
        talkingAudioSource.Play();
        animator.SetBool("isTalking", true);
    }

    private void StopTalkingSound() {
        endFirstPhrase = true;
        talkingAudioSource.Stop();
        animator.SetBool("isTalking", false);
        //uiCanvas.SetActive(false);
    }

    private void Start() {
        //TextWriter.AddWriter_Static(messageText, "This is the assistant speaking, hello and goodbye, see you next time!", .1f, true);
    }

    void Update(){
        
    }

}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// public class UI_Assistant : MonoBehaviour
// {
//     [SerializeField]
//     private TextWriter textWriter;
//     private Text messageText;
//     private void Awake()
//     {
//         messageText = transform.Find("Messages").Find("messageText").GetComponentInChildren<Text>();
//         Application.targetFrameRate = 3;
//     }
//     void Start()
//     {
//         messageText.text ="Hello Wolrd";
//         textWriter.AddWriter(messageText,"Hello World", .1f,true);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
    
// }
