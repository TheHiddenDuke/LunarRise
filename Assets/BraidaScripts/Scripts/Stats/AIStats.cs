using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : PartyStats
{

    public bool running = false;

    public float time = 0;

    

    public override void Die()
    {
        
        base.Die();
        //underAttack = false;
        attacking = false;
        //Destroy(gameObject);

    }
    
    public void FixedUpdate()
    {

        if (dead)
        {
            if (time >= 5.3f)
            {
                Destroy(gameObject);
            }
            time = time + Time.deltaTime;
        }
    }
}
