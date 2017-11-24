using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    public bool attacking = false;

	public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        playerStats.attackMode = false;
       
    }
}
