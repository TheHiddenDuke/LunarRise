using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyAnimator : MonoBehaviour {

    Animator anim;
    NavMeshAgent agent;
    public float speed;
    public float life;
    PlayerStats playerStats;
    AIStats aIStats;
    AIController aIController;

    // Use this for initialization
    void Start () {
        agent = GetComponentInParent<NavMeshAgent>();
        aIStats = GetComponentInParent<AIStats>();
        anim = GetComponent<Animator>();
        aIController = GetComponentInParent<AIController>();
        anim.SetBool("Running", false);
        anim.SetBool("Punching", false);
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetFloat("Life", life = aIStats.currentHealth);

        if (playerStats.running)
        {
            agent.speed = 15;
            agent.acceleration = 5;
            anim.SetBool("Running", true);
        }
        if (!playerStats.running)
        {
            agent.speed = 5;
            agent.acceleration = 3;
            anim.SetBool("Running", false);
        }
        if (aIStats.attacking&&(aIController.abilityRecuperationTime<=0))
        {
            anim.SetBool("Punching", true);
        }
        else 
        {
            anim.SetBool("Punching", false);
        }
        if(aIStats.underAttack && !aIStats.attacking)
        {
            anim.SetBool("TakeHit", true);
        }
        else
        {
            anim.SetBool("TakeHit", false);
        }
    }
}
