using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class World : MonoBehaviour
{
    private Animator animator;
    public bool levelOneOk = false;
    public UnityEvent whenTurnMenu;
    public float timeBeforeOpen = 2f;
    public MenuGame_Manager menuGame;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        menuGame = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(menuGame.levelNow==0)
        {
            Debug.Log("zero menu");
        }
        else if(menuGame.levelNow==1)
        {
            levelOneOk = true;
            animator.SetBool("levelOneOk", true);
            Debug.Log("one menu");
            StartCoroutine(OpenTheDoorMenu());
        }
        else if(menuGame.levelNow==2)
        {
            animator.SetBool("levelTwoOk", true);
            Debug.Log("two menu");
            StartCoroutine(OpenTheDoorMenu());
        }

        // if (levelOneOk) whenTurnMenuZeroToOne?.Invoke();
    }
    private IEnumerator OpenTheDoorMenu()
    {
        yield return new WaitForSeconds(timeBeforeOpen);
        OpenDoor();
    }
    void OpenDoor()
    {
        whenTurnMenu?.Invoke();
    }
    
}
