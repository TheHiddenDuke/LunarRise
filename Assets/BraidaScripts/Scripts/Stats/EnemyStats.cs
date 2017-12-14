using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    public int providedXP;
    public float time = 0;
    public List<Transform> items = new List<Transform>();



    public override void Die()
    {
        //Makes shure that the enemy is no longer targetting anyone
        GetComponent<EnemyController>().targetStats = null;
        GetComponent<EnemyController>().target = null;
        base.Die();
        //Take all characters out of attacking and under attack state
        CharacterStats playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        PlayerManager.instance.partyAllies[0].GetComponent<CharacterStats>().attacking = false;
        PlayerManager.instance.partyAllies[1].GetComponent<CharacterStats>().attacking = false;
        PlayerManager.instance.partyAllies[0].GetComponent<CharacterStats>().underAttack = false;
        PlayerManager.instance.partyAllies[1].GetComponent<CharacterStats>().underAttack = false;
        playerStats.attacking = false;
        playerStats.underAttack = false;
        //Get the enemy out of attack and under attack stats
        attacking = false;
        underAttack = false;
        //Delivers xp to the level system
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

