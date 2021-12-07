using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{

    public GameObject FallingTile; 
    public float spawninterval; 
    public float nextspawn;   
    public float speed = 1.0F;
    private float startTime;
    public LevelManager levelMananager;
    void Start()
    {
        nextspawn = Time.time+spawninterval; 
        // Keep a note of the time the movement started.
        startTime = Time.time;

    }

    // Move to the target end position.
    void Update()
    {
        if(Time.time > nextspawn)
        {
            nextspawn = Time.time+spawninterval; 
            SpawnTiles(); 
        }
       
    }
   
  
    void SpawnTiles()
    {
        float stepSize = 3;
        float GetRandomPositionX () {
            float randomTilePosition = Random.Range(0, levelMananager.miao);
            float numSteps = Mathf.Floor (randomTilePosition / stepSize);
            float adjustedFallingTile = numSteps * stepSize;
        
            return adjustedFallingTile;
        }
        float GetRandomPositionZ () {
            float randomTilePosition = Random.Range(0, levelMananager.bau);
            float numSteps = Mathf.Floor (randomTilePosition / stepSize);
            float adjustedFallingTile = numSteps * stepSize;
        
            return adjustedFallingTile;
        }
        Vector3 fallingTilePosition = new Vector3(GetRandomPositionX(),5,GetRandomPositionZ());
        Debug.Log(fallingTilePosition+ " falling tile position");
        // Vector3 fallingTilePosition = new Vector3((Random.Range(0,levelMananager.miao)),5,(Random.Range(0,levelMananager.bau)));
        // Debug.Log(fallingTilePosition+ " falling tile position");
        Instantiate(FallingTile,fallingTilePosition, transform.rotation);
        //Instantiate(FallingTile,transform.position, transform.rotation);
    }

}
