using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Grizzy : MonoBehaviour
{
    private NavMeshAgent agent;
    public LevelManager levelManager; 
    private float MaxDistance;
    private float distanceGrizzyTile;
    private Pool pool;
    public PlayerManager playerManager;
    public AudioSource audioSource;
    
    
    
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(1,100);
        agent.speed = Random.Range(1f,6f);
        levelManager =  FindObjectOfType<LevelManager>();
        NextDestination();
        if (levelManager == null)
        {
            Debug.LogError("There is no LevelManager in your scene");
        } 
        //playerManager =  gameObject.GetComponent<PlayerManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("There is no playerManager in your scene");
        } 
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager != null)
        {
            print("OK^^");
        }
        else{
            Debug.Log("error player manager not found");
        }
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
            //Debug.Log("update next destination");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Grizzy touch Greeny");
            playerManager.GreenyDamage(50f);
        }
        
    }
    private void NextDestination()
    {
        MaxDistance = Mathf.Infinity;
        Tile_Behaviour memoTile = null;
        
        foreach(Tile_Behaviour tile in levelManager.tiles)
        {
            if(!tile.isTileTrasformed) continue;
            //calculer la distance
            distanceGrizzyTile = Vector3.Distance(tile.transform.position, transform.position);
            //Debug.Log("miao distance");
            if(distanceGrizzyTile < MaxDistance)
            {
                //Debug.Log("grizzy peut commencer a choisir");
                memoTile = tile;
                MaxDistance = distanceGrizzyTile;
            }
        }
        if(memoTile != null)
        {agent.SetDestination(memoTile.transform.position); 
        //Debug.Log("setting distance okay");
        }
    }
    private void OnDrawGizmos() 
    {
        if (agent != null)
        {
            Gizmos.DrawSphere(transform.position + Vector3.up *2,
         0.05f + (100-agent.avoidancePriority)*0.01f);
        }
    }
}

