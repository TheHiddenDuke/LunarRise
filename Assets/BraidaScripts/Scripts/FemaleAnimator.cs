using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FemaleAnimator : MonoBehaviour {

    Animator anim;
    NavMeshAgent agent;
    public float speed;
    PlayerStats playerStats;
    PlayerStats aIStats;

    // Use this for initialization
    void Start () {
        agent = GetComponentInParent<NavMeshAgent>();
        aIStats = GetComponentInParent<PlayerStats>();
        anim = GetComponent<Animator>();
        anim.SetBool("Running", false);
        anim.SetBool("Punching", false);
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        
        if (playerStats.running)
        {
            anim.SetBool("Running", true);
        }
        if (!playerStats.running)
        {
            anim.SetBool("Running", false);
        }
        if (aIStats.attacking)
        {
            anim.SetBool("Punching", true);
        }
        if (!aIStats.attacking)
        {
            anim.SetBool("Punching", false);
        }
        if (aIStats.underAttack && !aIStats.attacking)
        {
            anim.SetBool("TakeHit", true);
        }
        else
        {
            anim.SetBool("TakeHit", false);
        }
    }
}
