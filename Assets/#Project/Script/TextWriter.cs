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
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        CharacterIndex=0;
    }
    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                //Display next character
                timer += timePerCharacter;
                CharacterIndex++;
                uiText.text = textToWrite.Substring(0,CharacterIndex);
                if(CharacterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}

