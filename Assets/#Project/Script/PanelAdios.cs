using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAdios : MonoBehaviour
{

    public Animator animator;
    public bool isPanelOk = true;
    public float timeMaxAnim =3.0f;
    public float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPanelOk)
        {
            animator.SetTrigger("panelOk");
        }
        currentTime += Time.deltaTime;
        if(currentTime >= timeMaxAnim)
        {
            isPanelOk= false;
        }
    }
}
