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
        
        explosion = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<Explosion>();
        
    }

    void Update()
    {
        
        if (isTransforming)
        {
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


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Television"))
        {
            //print("television trigger");
            StartCoroutine(TransformActivation());
        }
        }
    IEnumerator TransformActivation()
    {
        yield return new WaitForSeconds(waitTransformation);
        isTransforming=true;
        explosion.Explode(); 
    }
}
