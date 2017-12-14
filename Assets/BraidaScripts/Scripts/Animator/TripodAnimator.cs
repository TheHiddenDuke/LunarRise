using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TripodAnimator : MonoBehaviour {

    public Animator anim;
    NavMeshAgent agent;
    public float speed;
    public float life;
    EnemyStats enemyStats;
    EnemyController enemyController;
    
    
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
        anim.SetFloat("Speed", speed = agent.velocity.magnitude);
        anim.SetFloat("Life", life = enemyStats.currentHealth);
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
