
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistant : MonoBehaviour {

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private Animator animator;

    private void Awake() {
        messageText = transform.Find("Messages").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();

        transform.Find("Messages").GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive()) {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            } else {
                string[] messageArray = new string[] {
                    "This is the assistant speaking, hello and goodbye, see you next time!",
                    "Hey there!",
                    "This is a really cool and useful effect",
                    "Let's learn some code and make awesome games!",
                    "Check out Battle Royale Tycoon on Steam!",
                };

                string message = messageArray[Random.Range(0, messageArray.Length)];
                StartTalkingSound();
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, StopTalkingSound);
            }
        };
    }

    private void StartTalkingSound() {
        talkingAudioSource.Play();
        animator.SetBool("isTalking", true);
    }

    private void StopTalkingSound() {
        talkingAudioSource.Stop();
        animator.SetBool("isTalking", false);
    }

    private void Start() {
        //TextWriter.AddWriter_Static(messageText, "This is the assistant speaking, hello and goodbye, see you next time!", .1f, true);
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
