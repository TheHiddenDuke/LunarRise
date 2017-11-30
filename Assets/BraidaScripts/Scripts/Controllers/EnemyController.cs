using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Transform target;
    //GameObject target;
    NavMeshAgent agent;
    CharacterCombat combat;
    EnemyStats enemyStats;
    
  
    public float lookRadius = 10f;
	// Use this for initialization
	void Start () {
        //target = GameObject.FindGameObjectWithTag("Respawn").transform;
        target = FindClosestEnemy();
        //target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        enemyStats = GetComponent<EnemyStats>();
	}
    private void FixedUpdate()
    {
        target = FindClosestEnemy();
    }
    // Update is called once per frame
    void Update ()
    {
        if (enemyStats.currentHealth <= 0.1f)
        {
            target = null;
            enemyStats.attacking = false;
        }
        else
        {
            target = FindClosestEnemy();
            float distance = Vector3.Distance(target.position, transform.position);
            //if (target != null)
            //{

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    CharacterStats targetStats = target.GetComponent<CharacterStats>();
                    if (targetStats != null)
                    {
                        combat.Attack(targetStats);
                        enemyStats.attacking = true;

                    }
                    if (targetStats == null)
                    {
                        enemyStats.attacking = false;
                    }
                    FaceTarget();
                }
            }
            //}

        }
	}
    public Transform FindClosestEnemy()
    {
        GameObject[] gos;
        CharacterStats goStats;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            goStats = go.GetComponent<CharacterStats>();
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && (goStats.currentHealth >= 0))
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest.transform;
    }
    
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
