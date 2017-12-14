using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{

    public Animator anim;
    public SpeedDetection playerSpeed ;
    public bool speed;
    public float life;
    PlayerStats playerStats;
    Transform test;
    

    // Use this for initialization
    void Start()
    {
        playerSpeed = GetComponentInParent<SpeedDetection>();
        playerStats = GetComponentInParent<PlayerStats>();
        anim = GetComponent<Animator>();
        //anim.SetBool("Running", false);
        //anim.SetBool("Punching", false);
        

    }

    // Update is called once per frame
    void Update()
    {

        if (playerSpeed.speed)
        {
            speed = playerSpeed.speed;
            anim.SetBool("Speed", true);
        }
        if(!playerSpeed.speed)
        {
            anim.SetBool("Speed", false);
        }
        if (playerStats.running)
        {
            anim.SetBool("Running", true);
        }
        if (!playerStats.running)
        {
            anim.SetBool("Running", false);
        }
        if (playerStats.attacking)
        {
            anim.SetBool("Attacking", true);
        }
        if (!playerStats.attacking)
        {
            anim.SetBool("Attacking", false);
        }
        /*if (aIStats.underAttack && !aIStats.attacking)
        {
            anim.SetBool("TakeHit", true);
        }
        else
        {
            anim.SetBool("TakeHit", false);
        }*/
    }
}
