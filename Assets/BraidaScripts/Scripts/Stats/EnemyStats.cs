using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    
    public float time = 0;
    //Transform mycontroler;

    /*public void Start()
    {
        mycontroler
    }*/


    public override void Die()
    {
        base.Die();
        CharacterStats playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        playerStats.attacking = false;
        attacking = false;
        
        
       
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
