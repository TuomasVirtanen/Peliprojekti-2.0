using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("took damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Play dying animation

        //disable enemy

        Debug.Log("Enemy died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }

}


