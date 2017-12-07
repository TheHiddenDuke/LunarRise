using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interactable{
    PlayerManager playerManager;
    CharacterStats myStats;
    CharacterStats playerStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
        
    }

	public override void Interact()
    {
        base.Interact();
        
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        CharacterStats playerStats = playerManager.player.GetComponent<CharacterStats>();
        if (playerCombat != null)
        {

            playerCombat.Attack(myStats);
            playerStats.attacking = true;
            }
    }
}
