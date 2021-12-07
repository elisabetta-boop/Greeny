using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject PlayerPrefab;
    public GameObject player;

    public Vector3 StartPosLevels;

    public int levelNow;
    public bool counting = false;

    void Start()
    {
        if (instance==null && (levelNow == 1 || levelNow == 2 || levelNow ==3))
        {
            //DontDestroyOnLoad(gameObject);
            instance= this;
            player = Instantiate(PlayerPrefab, StartPosLevels, Quaternion.identity);
            //DontDestroyOnLoad(player);
            //Debug.Log("level zero");
        }
        else
        {
            Destroy(gameObject);
        }    
    }
    public void ResetPosLevel()
    {
        player.transform.position = StartPosLevels;
    }
    
    
    void Update()
    {

    }

}
