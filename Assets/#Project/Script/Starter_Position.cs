using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter_Position : MonoBehaviour
{
    void Start()
    {
        GameManager levelManager = GameManager.instance;
        GameObject player = levelManager.player;
        player.transform.position = transform.position;
    }
}
