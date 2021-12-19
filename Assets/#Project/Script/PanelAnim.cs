using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnim : MonoBehaviour
{
    public Animator littlLeftMouseAnimator;


    // Start is called before the first frame update
    void Start()
    {
        littlLeftMouseAnimator= GameObject.FindGameObjectWithTag("leftMouse").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        littlLeftMouseAnimator.SetTrigger("mouseOver");
    }
}
