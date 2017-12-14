using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/HealthItem")]
public class HealthItem : Item
{
    //public GameObject character = null;

    public int health;
    override public void Use()
    {

    }
    public void Use(GameObject character)
    {
        if (character != null)
        {
            character.GetComponent<PartyStats>().currentHealth = character.GetComponent<PartyStats>().currentHealth + health;
            
        }
    }

}
