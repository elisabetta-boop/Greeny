using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalBehaviour : MonoBehaviour
{
    public float timeToSplat=2;

    float time = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ScaleCoroutine()
    {
        Debug.Log("start coroutine");
        yield return new WaitForSeconds(timeToSplat);
        
        // Debug.Log("time "+time);
        // Debug.Log("Scale session");

        Vector3 originalScale = transform.localScale;
        Vector3 destinationScale = originalScale / 2;
        float currentTime = 0.0f;
        do 
        {   
            Debug.Log("doooo scale daiiii");
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime/time);
            currentTime += Time.deltaTime;
            //yield return true;     
        } while (currentTime<=time);

        //Debug.Log("current time"+ currentTime);
        Destroy(gameObject,10f);
    }

    public void ScaleOverTime()
    {
        StartCoroutine("ScaleCoroutine");
    }

    // {
    //     Debug.Log("time "+time);
    //     Debug.Log("Scale session");
    //     Vector3 originalScale = splat.transform.localScale;
    //     Vector3 destinationScale = originalScale*10;
    //     float currentTime = 0;
    //     float startTimeScale = 0;
    //     do 
    //     {
    //         startTimeScale +=Time.deltaTime;
    //             if (startTimeScale >= time)
    //             {
    //                 Debug.Log("start time to scale" + startTimeScale);
    //                 Debug.Log("doooo scale daiiii");
    //                 splat.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime/time);
    //                 currentTime += Time.deltaTime;
    //                 //yield return true;
    //             }
    //     } while (currentTime<=time);

    //     Debug.Log("current time"+ currentTime);
    //     Destroy(splat,10); 
    // }
}
