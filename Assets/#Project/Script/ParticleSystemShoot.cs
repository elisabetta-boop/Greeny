using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemShoot : MonoBehaviour
{
    public bool particles = false;
    public ParticleSystem myParticleSystem;
    public GameObject spark;
    public float timeShoot=1;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (particles)
        {
            myParticleSystem.Play();
            particles = false;
            StartCoroutine("stopParticles");
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        print($"Particles ocllision: {other.tag}");
        if (other.CompareTag("Grizzy"))
        {
            int events = myParticleSystem.GetCollisionEvents(other, colEvents);
       
            Instantiate(spark, colEvents[0].intersection, Quaternion.LookRotation(colEvents[0].normal));
        }
        // int events = myParticleSystem.GetCollisionEvents(other, colEvents);
       
        // Instantiate(spark, colEvents[0].intersection, Quaternion.LookRotation(colEvents[0].normal));
    }
    public IEnumerator stopParticles()
    {
        yield return new WaitForSeconds(timeShoot);
        myParticleSystem.Stop();
    }
}
