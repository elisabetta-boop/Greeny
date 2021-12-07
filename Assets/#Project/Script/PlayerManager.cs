using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float maxHealth=100;
    public GameObject player;
    public Slider healthBar;
    //public GameObject healthBarUIGreeny;
    public bool dead;
    public float smoothing = 5;
    

    void Awake()
    {
        if(healthBar == null)
        {
            // healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
            // Debug.Log("healthbar found ... because null");
            healthBar = (Slider)FindObjectOfType(typeof(Slider));
            Debug.Log("healthbar found ... because null");
        }
        
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }
    void Start()
    {
        //InvokeRepeating("ReduceHealth",1,1);
    }
    // void ReduceHealth()
    // {
        
    //     Debug.Log("ciao "+ health);
    //     health = health -10;
    //     healthBar.value = health;
    //     if(health <= 0)
    //     {
    //         //player.GetComponent<Animator>.SetTrigger("isDead");
    //         Debug.Log("Greeny is dead  "+ health);
    //     }
    // }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Grizzy"))
    //     {
    //         Debug.Log("Greeny touch Grizzy");
    //         //GreenyDamage();
  
    //     }
    // }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.tag == "grizzy")
    //     {
    //         GreenyDamage(50f);
    //         Debug.Log("Greeny touch Grizzy");
    //     }
    // }
    
    // Update is called once per frame
    void Update()
    {
        // healthBar.value = health;
        // Debug.Log(healthBar + " healthupdate " + health);
        if(healthBar.value != health)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, health, smoothing*Time.deltaTime);
        }
    }
    public void GreenyDamage(float amount)
    {
        Debug.Log("Greeny take damage from grizzy: " + amount);

        health -= amount;
        healthBar.value = health;

        print("current health after grizzy touch " + health);

        if(health <= 0.0f)
        {
            health = 0;
            Debug.Log("GAME OVER");
            dead = true;
        }
    }
}
