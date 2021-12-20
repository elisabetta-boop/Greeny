using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SphereMenuZeroBehaviour : MonoBehaviour
{
    public Animator sphereAnim;
    
    public bool okAnimSphere=false;
     public UnityEvent whenHitSphereMenuZero;

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
    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);

        if (other.gameObject.tag == "Bullet")
        {
            
            MenuZeroRetour();
        }
    }

    public void MenuZeroRetour()
    {
        whenHitSphereMenuZero?.Invoke();
    }

    // Update is called once per frame
    
}
