using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public PlayerManager playerManager;
    void Start()
    {
        if (playerManager == null)
        {
            playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        playerManager.health +=20;
        // PlayerManager.health +=20;
        Debug.Log("Pickup");
        Destroy(this.gameObject);
    }
    


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
