using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame_Manager : MonoBehaviour
{
    public static MenuGame_Manager instance = null;

    public GameObject PlayerPrefabZero;
    public GameObject playerZero;
    public Vector3 StartPos;
    

  
    public int levelNow;
    
    public bool counting = false;
    public bool theSceneIsStarted = false;
    public TelevisionController televisionController;
    

    void Start()
    {
        if (instance==null && levelNow == 0)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero,StartPos,Quaternion.identity);
            //DontDestroyOnLoad(playerZero);
            //Debug.Log("level zero");
            televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        if (instance==null && levelNow == 1)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero,StartPos,Quaternion.identity);
            //DontDestroyOnLoad(playerZero);
            //Debug.Log("level zero");
            // televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        if (instance==null && levelNow == 2)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero,StartPos,Quaternion.identity);
            //DontDestroyOnLoad(playerZero);
            //Debug.Log("level zero");
            // televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        else
        {
            Destroy(gameObject);
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

    }

}
