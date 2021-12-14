using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius;
    public float power;
    public GameObject explosionVFX;
    void Start()
    {
    }
    public void Explode()
    {
        Vector3 explosionColorPos = transform.position;
        //Collider[] colliders  = Physics.OverlapSphere(explosionColorPos, radius);

        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);

        // foreach (Collider hit in colliders)
        // {
        //     Rigidbody rb = hit.GetComponent<RigidBody>();
        //     if (rb != null)
        //     {
        //         rb.AddExplosionForce(power, explosionColorPos, radius, 3.0f);
        //     }
        // }
        // Destroy(this.gameObject);
    }
}
