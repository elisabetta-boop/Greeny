using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerZeroTransformation : MonoBehaviour
{
    Material greenyZeroMaterial;
    // public Material greenyGreen;
    public bool isTransforming = false;
    private Television television;
    public float waitTransformation = 31;
    
    

    void Start()
    {
        greenyZeroMaterial = GetComponent<Renderer>().material;
       //greenyMaterial.color = Color.grey;
    }

    void Update()
    {
        // Debug.Log("daje trans"+isTransforming);
        // //if (isTransforming && myVideoPlayer.startVideo)
        // if ()  
        // {
        //     greenyZeroMaterial.color = Color.green;
        //     print("color transformation in greeny");
        // }
        if (isTransforming) //qui condizione trigger
        {
            greenyZeroMaterial.color = Color.green;
            print("color transformation in greeny");
        }

        else
        {
            //print("incredible nothing");
            greenyZeroMaterial.color = Color.grey;
        }
    }
    // public void ZeroTrasform()
    // {
    //     greenyZeroMaterial.color = Color.green;
    //     print("color transformation in greeny");
    // }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Television"))
        {
            //isTransforming = true;
            print("television trigger");
            // greenyMaterial.color = Color.green;
            // print("color transformation in greeny");

            StartCoroutine(TransformActivation());
        }
        }
    IEnumerator TransformActivation()
    {
        yield return new WaitForSeconds(waitTransformation);
        isTransforming=true;
    }
}
