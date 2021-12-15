using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionTimer
{
    public static FunctionTimer Create(Action action, float timer)
    {
        
        FunctionTimer functionTimer = new FunctionTimer(action, timer);
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;
        return functionTimer;
    }
    private class MonoBehaviourHook : MonoBehaviour { 
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
        }

    
    private Action action;
    private float timer;
    private bool something;

    public FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
    }
    public void Update()
    {
        if(!something)
        {
            timer -= Time.deltaTime;
            if(timer<0)
        {
            //trigger the action
            action();
            Something();
        }
        }
        
    }
    private void Something()
    {
        Debug.Log("something");
        something = true;
    }
    
}

