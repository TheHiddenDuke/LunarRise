using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interactable{
    PlayerManager playerManager;
    AIManager aiManager;
    AIManager2 aiManager2;
    CharacterStats myStats;
    CharacterStats playerStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        aiManager = AIManager.instance;
        aiManager2 = AIManager2.instance;
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
