using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrizzyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isPainted = false;
    public Slider healthBarGrizzy;
    public float currentHealth;
    public GameObject healthBarUI;
    public Pool pool;
    public Grizzy grizzy;
    public bool isDead=false;
    

    void Start()
    {
        currentHealth = maxHealth;
        //healthBarGrizzy.value = CalculateHealth();
        healthBarGrizzy.value = currentHealth;
        pool = FindObjectOfType<Pool>();
        grizzy = GetComponent<Grizzy>();
    }
    void Update()
    {
        //healthBarGrizzy.value = CalculateHealth();
        healthBarGrizzy.value = currentHealth;
        if (currentHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
            //Debug.Log("set active canvas....");
        } 
    }
    
    public void TakeDamage(float amount)
    {
        Debug.Log("take damage: " + amount);

        currentHealth -= amount;

        print("current health after shoot " + currentHealth);

        if(currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        Debug.Log("Death!! daiiiii");
        print((pool == null) + " pool");
        print((grizzy == null) + " grizzy");
        pool.Kill(grizzy);
    }

    // float CalculateHealth()
    // {
    //     // Debug.Log("calculate health");
    //     return currentHealth / maxHealth; 
    // }
    
}
