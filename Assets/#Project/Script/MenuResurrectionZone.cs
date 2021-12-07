using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResurrectionZone : MonoBehaviour
{
    public MenuGame_Manager gManager;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerZero"))
        {
            // TryLevelManager.LoseLife();
            //Debug.Log("falling");
            gManager.ResetPos();
             
        }
        else {

            Destroy(collision.gameObject);
        }
    }
}
