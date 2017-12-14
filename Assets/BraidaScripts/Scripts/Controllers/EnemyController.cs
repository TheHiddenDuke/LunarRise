using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    EnemyStats enemyStats;
    public CharacterStats targetStats;
    public float distance;



    public float lookRadius = 10f;
	// Use this for initialization
	void Start () {
        
        target = FindClosestEnemy();
        
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
            if (targetStats != null)
            {
                //Informs all the characters that they are no longer under attack
                //If this sets a false positive is not a problem sisnce underattack will be true again after the next damage
                PlayerManager.instance.player.GetComponent<PlayerStats>().underAttack = false;
                PlayerManager.instance.partyAllies[0].GetComponent<PartyStats>().underAttack = false;
                PlayerManager.instance.partyAllies[1].GetComponent<PartyStats>().underAttack = false;
            }
            target = null;
            enemyStats.attacking = false;
        }
        else
        {
            target = FindClosestEnemy();
            distance = Vector3.Distance(target.position, transform.position);
            targetStats = target.GetComponent<CharacterStats>();
            //if (target != null)
            //{

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    
                    if (targetStats != null)
                    {
                        combat.Attack(targetStats);
                        enemyStats.attacking = true;
                        targetStats.underAttack = true;

                    }
                    if (targetStats.dead)
                    {
                        enemyStats.underAttack = false;
                        enemyStats.attacking = false;
                    }
                    FaceTarget();
                }
            }
            else
            {
                enemyStats.attacking = false;
                enemyStats.underAttack = false;
            }
            /*if(distance> lookRadius)
            {
                enemyStats.attacking = false;
                //targetStats.underAttack = false;
                //Debug.Log("Esse eh o problema");

            }*/
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
