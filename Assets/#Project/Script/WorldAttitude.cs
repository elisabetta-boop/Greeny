using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAttitude : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // private void OnCollisioEnter(Collision other) {
    //     if (other.gameObject.tag=="Bullet")
    //     {
    //         Debug.Log("trigger bullet ambieht");
    //         audioSource.Play();
    //     }
    // }

    public void BulletAmbientSound()
    {
        audioSource.Play();
    }
}
