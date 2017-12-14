using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interactable{
    
    CharacterStats myStats;
    CharacterStats playerStats;

    void Start()
    {
       
        myStats = GetComponent<CharacterStats>();
        
    }

	public override void Interact()
    {
        base.Interact();
        
        CharacterCombat playerCombat = PlayerManager.instance.player.GetComponent<CharacterCombat>();
        CharacterStats playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        Animator anim = PlayerManager.instance.player.GetComponentInChildren<Animator>();
        if (playerCombat != null)
        {
            
            if (!playerStats.abilityAttack)
            {
                playerCombat.Attack(myStats);
                anim.SetTrigger("Punch");
                playerStats.attacking = true;
                Debug.Log("Enemy received a regular punch");
            }
            }
    }
}
