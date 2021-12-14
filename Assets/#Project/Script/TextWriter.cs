using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int CharacterIndex;
    private bool invisibleCharacters;
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        CharacterIndex=0;
    }
    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while(timer <= 0)
            {
                //Display next character
                timer += timePerCharacter;
                CharacterIndex++;
                string text = textToWrite.Substring(0,CharacterIndex);
                if(invisibleCharacters)
                {
                    text += "<color=#00000000>"+ textToWrite.Substring(CharacterIndex)+ "</color>";
                }
                uiText.text = text;

                if(CharacterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}

