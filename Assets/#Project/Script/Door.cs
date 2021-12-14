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
    public NewPlayerZero playerZero;
    public MenuGame_Manager menuGame_Manager;
    public NewPlayerZero newPlayerZero;

    private void Start() {
    
        animator= GetComponent<Animator>(); 
        //playerZero = GameObject.FindGameObjectWithTag("PlayerZero").GetComponentInChildren<NewPlayerZero>();
        menuGame_Manager = GameObject.FindGameObjectWithTag("MenuGame").GetComponent<MenuGame_Manager>();
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
        //playerZero.animator.CrossFade(playerZero.victoryAnimation, playerZero.animationPlayerTransition);
        StartCoroutine(StartMiaoVictoryAnimation());
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
