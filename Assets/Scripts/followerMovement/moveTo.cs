using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTo : MonoBehaviour {

    // Use this for initialization
    public Transform goal;
    public Transform other;
    


    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        float dist = Vector3.Distance(goal.position, transform.position);
        if (dist > 5f)
        {
            float distOther = Vector3.Distance(other.position, transform.position);
            /*
            if (distOther < 2f)
            {
                transform.position = transform.position;
            }*/
            agent.destination = goal.position;
        }
        else
        {
            agent.destination = transform.position; 
        }
        /*PlayerStats mainPlayerStats = mainPlayer.GetComponent<PlayerStats>();
        if(mainPlayerStats!= null)
        {
            if (mainPlayerStats.attackMode)
            {

            }
        }*/

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
}
