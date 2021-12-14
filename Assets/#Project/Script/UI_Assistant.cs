using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Assistant : MonoBehaviour
{
    [SerializeField]
    private TextWriter textWriter;
    private Text messageText;
    private void Awake()
    {
        messageText = transform.Find("Messages").Find("messageText").GetComponentInChildren<Text>();
        Application.targetFrameRate = 3;
    }
    void Start()
    {
        messageText.text ="Hello Wolrd";
        textWriter.AddWriter(messageText,"Hello World", .1f,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
