using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMenuZeroBehaviour : MonoBehaviour
{
    public Animator sphereAnim;
    
    public bool okAnimSphere=false;


    private void Awake()
    {
        
        sphereAnim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if(!okAnimSphere)
        {
            sphereAnim.SetTrigger("isSphereMenuZero");
        }
        
    }

    // Update is called once per frame
    
}
