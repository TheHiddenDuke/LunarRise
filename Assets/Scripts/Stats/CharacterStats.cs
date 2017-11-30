using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int maxStamina = 100;
    public int currentHealth;
    public int showHealth;
    public bool dead = false;
    public bool attacking = false;
    

    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        showHealth = currentHealth;
         
    }

    public void TakeDamage (int damage)
    {
        
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
            dead = true;
        }
    }

    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
