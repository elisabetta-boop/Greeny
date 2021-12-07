using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTelevision : MonoBehaviour
{
    public Light teleLight;
    

    
    void Start()
    {
        teleLight = GetComponent<Light>();
        float timeUntilInvoked = 3.0f;//Seconds to pass before invoke
        Invoke("TriggerFunction", timeUntilInvoked);//Invoke certain function after 3.0f seconds
    }
    void TriggerFunction() {
        StartCoroutine("FadeIn");//Start a coroutine to run independent from the update function
    }
    
    IEnumerator FadeIn() {
        float duration = 10.0f;//time you want it to run
        float interval = 0.1f;//interval time between iterations of while loop
        teleLight.intensity = 0.0f;
        while (duration >= 0.0f) {
            
            // lt.intensity += 0.02;
            // lt.intensity += augmentation;
            teleLight.intensity ++ ;
                
            duration -= interval;
            yield return new WaitForSeconds(interval);//the coroutine will wait for 0.1 secs
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LightGreen()
    {
        //StartCoroutine("LightGreenTV");
    }

    // IEnumerator LightGreenTV()
    // {
    //     float duration = 5.0f;//time you want it to run
    //     float interval = 0.1f;//interval time between iterations of while loop
    //     teleLight.intensity = 0.0f;
    //     while (duration >= 0.0f) {
    //         teleLight.intensity ++ ;   
    //         duration -= interval;
    //         yield return new WaitForSeconds(interval);//the coroutine will wait for 0.1 secs
    //     }
    // }
}
