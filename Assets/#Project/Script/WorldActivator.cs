using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldActivator : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("isFinish");
    }
}
