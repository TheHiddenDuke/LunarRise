using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interactable{
    PlayerManager playerManager;
    AIManager aiManager;
    AIManager2 aiManager2;
    CharacterStats myStats;
    PlayerStats playerStats;

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
        PlayerStats playerStats = playerManager.player.GetComponent<PlayerStats>();
        if (playerCombat != null)
        {

            playerCombat.Attack(myStats);
            playerStats.attackMode = true;
            }
    }
}
