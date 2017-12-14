using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    public int providedXP;
    public float time = 0;
    

    

    public override void Die()
    {
        GetComponent<EnemyController>().targetStats = null;
        GetComponent<EnemyController>().target = null;
        base.Die();
        CharacterStats playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        PlayerManager.instance.partyAllies[0].GetComponent<CharacterStats>().attacking = false;
        PlayerManager.instance.partyAllies[1].GetComponent<CharacterStats>().attacking = false;
        PlayerManager.instance.partyAllies[0].GetComponent<CharacterStats>().underAttack = false;
        PlayerManager.instance.partyAllies[1].GetComponent<CharacterStats>().underAttack = false;
        playerStats.attacking = false;
        playerStats.underAttack = false;
        attacking = false;
        LevelSystem.instance.gainedXP = LevelSystem.instance.gainedXP + providedXP;
        
        
       
    }
    public void FixedUpdate()
    {
        
        if (dead)
        {
            if(time >= 5.3f)
            {
                Destroy(gameObject);
            }
            time = time + Time.deltaTime;
        }
    }
}
