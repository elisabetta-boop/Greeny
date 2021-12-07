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

    private void Start() {
    
        animator= GetComponent<Animator>(); 
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
    }
}
