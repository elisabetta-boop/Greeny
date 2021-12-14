using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool doorIsOpen = false;
    private Animator animator;
    public bool TheLevelIsPassed = false; //to do: destroy player

    public UnityEvent whenEnter;
    public float timeToMiaoVictory=3.0f;

    //public NewPlayerZero playerZero;
    public UnityEvent whenVictoryPlayerZero;
    public MenuGame_Manager menuGame_Manager;
    public NewPlayerZero newPlayerZero;
    private void Start() {
        animator= GetComponent<Animator>();
        menuGame_Manager = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
        //newPlayerZero = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<NewPlayerZero>();
        //newPlayerZero = GameObject.Find("PlayerZeroName").GetComponentInChildren<NewPlayerZero>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerZero") && doorIsOpen) {
            whenEnter?.Invoke();
            TheLevelIsPassed = true;
        }
    }
    public void Unlock() {
        doorIsOpen = true;
        animator.SetBool("doorIsOpen", true);

        StartCoroutine(StartMiaoVictoryAnimation());

        //playerZero.animator.CrossFade(playerZero.victoryAnimation, playerZero.animationPlayerTransition);
    }
    IEnumerator StartMiaoVictoryAnimation()
    {
        newPlayerZero = GameObject.FindGameObjectWithTag("PlayerZero").GetComponent<NewPlayerZero>();
        yield return new WaitForSeconds(timeToMiaoVictory);
        //whenVictoryPlayerZero?.Invoke();
        Debug.Log("inside the coroutine miaoVictory");
        newPlayerZero.MiaoVictoryAnimation();
        
    }
}
