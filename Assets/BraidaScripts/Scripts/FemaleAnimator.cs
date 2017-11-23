using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FemaleAnimator : MonoBehaviour {

    Animator anim;
    NavMeshAgent agent;
    public float speed;
    PlayerStats playerStats;

    // Use this for initialization
    void Start () {
        agent = GetComponentInParent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Running", false);
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        
        if (playerStats.running)
        {
            anim.SetBool("Running", true);
        }
    }
}
