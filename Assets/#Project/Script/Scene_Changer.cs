using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    //public bool levelOne = false;
    public void Load(string destination) {
        
        SceneManager.LoadScene(destination);
        if(destination == "Level_1") 
        {
            //Debug.Log("livello 1");
            //levelOne = true;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
