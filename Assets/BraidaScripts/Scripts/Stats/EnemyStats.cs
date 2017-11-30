using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    //public bool attacking = false;
    public float time = 0;
    //Transform mycontroler;

    /*public void Start()
    {
        mycontroler
    }*/


    public override void Die()
    {
        base.Die();
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        playerStats.attackMode = false;
        attacking = false;
        //Destroy(gameObject);
        /*TripodAnimator tripodAnimator = GetComponentInChildren<TripodAnimator>();
        tripodAnimator.anim.SetBool("Life", false);
        */
        
       
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
