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
    public bool underAttack = false;
    
    
    
    public bool abilityAttack = false;
    
    Animator anim;
    public Stat damage;
    public Stat armor;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
         
    }
    public void TakeDamageFromAbility(int damage) { 
}
    public void TakeDamage (int damage, string namel)
    {
        
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
       
        
            
            currentHealth -= damage;
            Debug.Log(transform.name + " takes " + damage + " damage." + namel);
            underAttack = true;
            if (currentHealth <= 0.1f)
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
