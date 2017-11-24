using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TripodAnimator : MonoBehaviour {

    Animator anim;
    NavMeshAgent agent;
    public float speed;
    EnemyStats enemyStats;
    
    // Use this for initialization
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        enemyStats = GetComponentInParent<EnemyStats>();
        anim = GetComponent<Animator>();
        anim.SetBool("Attack", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        if (enemyStats.attacking)
        {
            anim.SetBool("Attack", true);
        }
        if (!enemyStats.attacking)
        {
            anim.SetBool("Attack", false);
        }
    }   
}
