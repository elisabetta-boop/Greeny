using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStarterPosition : MonoBehaviour
{
    void Start()
    {
        MenuGame_Manager gameManager = MenuGame_Manager.instance;
        GameObject playerZero = gameManager.playerZero;
        playerZero.transform.position = transform.position;
    }
}
