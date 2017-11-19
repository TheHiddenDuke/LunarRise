using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    GameObject mainPlayer;
    Transform target;
    NavMeshAgent agent;

    public float lookRadius = 10f;
    // Use this for initialization
    void Start()
    {
        mainPlayer = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
            agent.SetDestination(mainPlayer.transform.position);
        PlayerStats mainPlayerStats = mainPlayer.GetComponent<PlayerStats>();
        if(mainPlayerStats!= null)
        {
            if (mainPlayerStats.attackMode)
            {
                cylMove playerController = mainPlayer.GetComponent<cylMove>();
                target = playerController.focus.transform;
                agent.SetDestination(target.position);
                float distance = Vector3.Distance(target.position, transform.position);
                //target = FindClosestEnemy();
                if (distance <= lookRadius)
                {
                    agent.SetDestination(target.transform.position);
                    if (distance <= agent.stoppingDistance)
                    {
                        CharacterStats targetStats = target.GetComponent<CharacterStats>();
                        CharacterCombat combat = this.GetComponent<CharacterCombat>();
                        if (targetStats != null)
                        {
                            combat.Attack(targetStats);
                        }
                        FaceTarget();
                    }
                }
            }
        }

        /*
         * float distance = Vector3.Distance(target.transform.position, transform.position);
        //target = FindClosestEnemy();
        if (distance<= lookRadius)
        {
            agent.SetDestination(target.transform.position);
            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                FaceTarget();
            }
        }
         * 
         * 
         * 
            */

        /*
         * public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
            */



    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}


