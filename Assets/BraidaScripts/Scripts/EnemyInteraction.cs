using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interactable{
    PlayerManager playerManager;
    AIManager aiManager;
    AIManager2 aiManager2;
    CharacterStats myStats;

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
        CharacterCombat aiCombat = aiManager.ai.GetComponent<CharacterCombat>();
        CharacterCombat aiCombat2 = aiManager2.ai.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
            //playerStats.attackMode = true;
            if (aiCombat != null)
            {
                aiCombat.Attack(myStats);
                if (aiCombat2 != null) {
                    aiCombat2.Attack(myStats);
                        }
            }
        }
    }
}
