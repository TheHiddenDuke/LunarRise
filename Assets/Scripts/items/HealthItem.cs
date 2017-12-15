using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/HealthItem")]
public class HealthItem : Item
{
    //public GameObject character = null;

    public int health;
    int healthIncrease;
    override public void Use()
    {

    }
    public void Use(GameObject character)
    {
        if (character != null)
        {
            PartyStats characterStats = character.GetComponent<PartyStats>();
            if (characterStats.maxHealth > characterStats.currentHealth)
            {
                if (characterStats.maxHealth >= characterStats.currentHealth + health)
                {
                    characterStats.currentHealth = characterStats.currentHealth + health;
                }
                else
                {
                    characterStats.currentHealth = characterStats.maxHealth;
                }
            }
            else
            {
                Debug.Log("Already with full life");
            }
            
            
        }
    }

}
