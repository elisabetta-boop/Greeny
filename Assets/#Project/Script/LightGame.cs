using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGame : MonoBehaviour
{
    public Timer timer;
    public Light lt;
    // double augmentation = 0.02;
    void Start() {
        lt = GetComponent<Light>();
        float timeUntilInvoked = 3.0f;//Seconds to pass before invoke
        Invoke("TriggerFunction", timeUntilInvoked);//Invoke certain function after 3.0f seconds
    }
    
    void TriggerFunction() {
        StartCoroutine("FadeIn");//Start a coroutine to run independent from the update function
    }
    
    IEnumerator FadeIn() {
        float duration = 5.0f;//time you want it to run
        float interval = 0.1f;//interval time between iterations of while loop
        lt.intensity = 0.0f;
        while (duration >= 0.0f) {
            
            // lt.intensity += 0.02;
            // lt.intensity += augmentation;
            lt.intensity ++ ;
                
            duration -= interval;
            yield return new WaitForSeconds(interval);//the coroutine will wait for 0.1 secs
        }
    }

}
