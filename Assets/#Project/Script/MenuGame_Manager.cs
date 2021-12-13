using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame_Manager : MonoBehaviour
{
    public static MenuGame_Manager instance = null;
    public GameObject[] PlayerPrefabZero;
    // public GameObject PlayerPrefabZero;
    // public GameObject GreenPlayerPrefabZero;
    public GameObject playerZero;
    public Vector3 StartPos;
    

  
    public int levelNow;
    
    public bool counting = false;
    public bool theSceneIsStarted = false;
    public TelevisionController televisionController;
    public NewPlayerZeroTransformation newPlayerZeroTransformation;
    
    

    void Start()
    {
        if (instance==null && levelNow == 0)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero[0],StartPos,Quaternion.identity);
            //DontDestroyOnLoad(playerZero);
            //Debug.Log("level zero");
            televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        if (instance==null && levelNow == 1)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero[1],StartPos,Quaternion.identity);
            //DontDestroyOnLoad(playerZero);
            //Debug.Log("level zero");
            // televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        if (instance==null && levelNow == 2)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero[1],StartPos,Quaternion.identity);
            //DontDestroyOnLoad(playerZero);
            //Debug.Log("level zero");
            // televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        else
        {
            Destroy(gameObject);
        }
        newPlayerZeroTransformation = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<NewPlayerZeroTransformation>();
        if(newPlayerZeroTransformation== null)
        {
            Debug.Log("newPlayerZeroTransformation null"+newPlayerZeroTransformation);
        }
        else
        {
            Debug.Log("newPlayerZeroTransformation ok"+newPlayerZeroTransformation);
        }    
        
    }
    public void ResetPos()
    {
        playerZero.GetComponent<CharacterController>().enabled = false;
        playerZero.transform.position = StartPos;
        playerZero.GetComponent<CharacterController>().enabled = true;

    }
    
    
    void Update()
    {
        //if(newPlayerZeroTransformation.isTransforming)
        // {
        //     Debug.Log("is transforming in menuGame manager "+newPlayerZeroTransformation.isTransforming);
        //     Destroy(playerZero.gameObject);
        //     ChangeGreeny();
        // }
    }

    public void ChangeGreeny()
    {
        
        // instance = this;
        // playerZero = Instantiate(GreenPlayerPrefabZero,newPlayerZeroTransformation.lastPositionGreenyGrizzy,Quaternion.identity) as GameObject;
        instance= this;
        playerZero = Instantiate(PlayerPrefabZero[1],newPlayerZeroTransformation.lastPositionGreenyGrizzy,Quaternion.identity);
        
        Debug.Log("change greeny");
    }

}
