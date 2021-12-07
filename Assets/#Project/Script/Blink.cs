using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public Text text;
   
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    IEnumerator blinkMe()
    {
        while (true)
        {
            switch(text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b,1);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b,0);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
        
    }
    public void StartBlinking()
    {
        StopCoroutine("blinkMe");
        StartCoroutine("blinkMe");
    }
    public void StopBlinking()
    {
        StopCoroutine("blinkMe");
    }
}
