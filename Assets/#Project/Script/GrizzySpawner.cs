using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrizzySpawner : MonoBehaviour
{
    public Object grizzy; 
    public float spawninterval; 
    public float nextspawn; 

    public Pool pool;
 
    
    void Start ()
    {
        nextspawn = Time.time+spawninterval; 
    }    
    void Update ()
    {
        if(Time.time > nextspawn)
        {
            nextspawn = Time.time+spawninterval; 
            SpawnGrizzy(); 
        }
    }
 
    void SpawnGrizzy()
    {
        Grizzy grizzy = pool.Create(transform.position, transform.rotation);
        // Instantiate(grizzy,transform.position, transform.rotation); // create zombie
    }
}
