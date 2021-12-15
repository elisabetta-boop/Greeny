using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuGame_Manager : MonoBehaviour
{
    public static MenuGame_Manager instance = null;
    public GameObject[] PlayerPrefabZero;
    // public GameObject PlayerPrefabZero;
    // public GameObject GreenPlayerPrefabZero;
    public GameObject playerZero;
    public Vector3 StartPos;
    public UI_Assistant uiAssistant;
    public UnityEvent whenStart;
    

  
    public int levelNow;
    
    public bool counting = false;
    public bool theSceneIsStarted = false;
    public TelevisionController televisionController;
    public NewPlayerZeroTransformation newPlayerZeroTransformation;
    public float timeToMessage = 0.1f;
    public float timeToTelevision = 5f;

    public  float timer = 2.0f;
    
    //public CanvasMessageStart canvasMessageStart;
    

    void Start()
    {
        if (instance==null && levelNow == 0)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero[0],StartPos,Quaternion.identity);
            //theSceneIsStarted = true;
            //coroutine active message 
            //whenStart?.Invoke();
            //Invoke("StartTheMessage",2.0f);

            
            //coroutine pour television
            televisionController.TVanimator.SetBool("sceneStart", true);  
        }
        if (instance==null && levelNow == 1)
        {
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero[1],StartPos,Quaternion.identity);

        }
        if (instance==null && levelNow == 2)
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            playerZero = Instantiate(PlayerPrefabZero[1],StartPos,Quaternion.identity);
             
        }
        else
        {
            Destroy(gameObject);
        }
        //canvasMessageStart = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<CanvasMessageStart>();

        
        //newPlayerZeroTransformation = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<NewPlayerZeroTransformation>();
        // if(newPlayerZeroTransformation== null)
        // {
        //     Debug.Log("newPlayerZeroTransformation null"+newPlayerZeroTransformation);
        // }
        // else
        // {
        //     Debug.Log("newPlayerZeroTransformation ok"+newPlayerZeroTransformation);
        // }    
        //uiAssistant = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UI_Assistant>();
        
        
    }
    public void ResetPos()
    {
        playerZero.GetComponent<CharacterController>().enabled = false;
        playerZero.transform.position = StartPos;
        playerZero.GetComponent<CharacterController>().enabled = true;

    }
    
    
    void Update()
    {
        // if(canvasMessageStart == null)
        // {
        //     Invoke("canvasMessageStart.StartMessage", 2.0f);
        // }
        
    }

    // IEnumerator StartMEssage()
    // {

    // }

    // void StartTheMessage()
    // {
    //     canvasMessageStart.StartMessage();
    // }
    
    

}
