using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius;
    public float power;
    Vector3 explosionPos;
    public GameObject explosionGameObject;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode()
    {
        explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        GameObject explosion = Instantiate(explosionGameObject, transform.position, Quaternion.identity);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power,explosionPos, radius, 3,0f);
            }
        }
    }
}
