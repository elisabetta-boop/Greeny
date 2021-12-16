using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewPlayerZeroTransformation : MonoBehaviour
{
    Material greenyZeroMaterial;
    // public Material greenyGreen;
    public bool isTransforming = false;
    private Television television;
    public float waitTransformation = 31;
    //public Material greenTransformationMaterial;
    public GameObject PlayerZeroGreeny;

    private GameObject playerZeroGreen;
    public Transform zeroPlayerTransform;
    private Vector3 lastPosition;
    public MenuGame_Manager menuGame_Manager;
    public Vector3 lastPositionGreenyGrizzy;
    public Explosion explosion;
    
    
    

    void Start()
    {
        menuGame_Manager = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
        if(menuGame_Manager== null)
        {
            Debug.Log("menu game manager null");
        }
        else{
            Debug.Log("menu game manager ok");
        }
        explosion = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<Explosion>();
        // greenyZeroMaterial = GetComponentInChildren <Renderer>().material;
        // if(greenyZeroMaterial== null)
        // {
        //     Debug.Log("greeny material null");

        // }
        // else{
        //     Debug.Log("greeny material ok"+greenyZeroMaterial);
        // }
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
        // if (isTransforming) //qui condizione trigger
        // {
        //     //greenyZeroMaterial.color = Color.green;
        //     // greenyZeroMaterial = greenTransformationMaterial;
        //     // print("color transformation in greeny"+ greenyZeroMaterial);
        //     // lastPosition = gameObject.transform.position;
        //     // ChangeGreeny();
        //     Destroy(gameObject);
         //}

        // else
        // {
        //     print("incredible nothing");
        //     //greenyZeroMaterial.color = Color.grey;
        // }
        if (isTransforming)
        {
            // lastPositionGreenyGrizzy = gameObject.transform.position;
            // Destroy(gameObject);
            // menuGame_Manager.ChangeGreeny();
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                // To preserve transparency
                float alpha = renderer.material.color.a;
                renderer.material.color = new Color(0, 1, 0, alpha);
                // Don't change the color all the time
                isTransforming = false;
            }
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
        explosion.Explode();
    }
    // public void ChangeGreeny()
    // {
    //     // PlayerZeroGreeny.GetComponent<CharacterController>().enabled = false;
    //     // playerZeroGreen = Instantiate(PlayerZeroGreeny, lastPosition, Quaternion.identity);
    //     // playerZeroGreen.GetComponent<CharacterController>().enabled = true;
        

    // }
}
