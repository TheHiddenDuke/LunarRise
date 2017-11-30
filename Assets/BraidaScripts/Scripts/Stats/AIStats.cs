using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : CharacterStats
{

    public bool running = false;

    public float time = 0;


    public override void Die()
    {
        base.Die();
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
