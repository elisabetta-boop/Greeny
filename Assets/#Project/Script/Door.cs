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

    private void Start() {
    
        animator= GetComponent<Animator>(); 
        //playerZero = GameObject.FindGameObjectWithTag("PlayerZero").GetComponentInChildren<NewPlayerZero>();
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
        yield return new WaitForSeconds(timeToMiaoVictory);
        whenVictoryPlayerZero?.Invoke();
        Debug.Log("inside the coroutine miaoVictory");
    }
}
