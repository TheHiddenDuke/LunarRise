using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    GameObject mainPlayer;
    public Transform target;
    NavMeshAgent agent;
    public Transform goal;
    public Transform other;
    



    public float lookRadius = 10f;
    // Use this for initialization
    void Start()
    {
        mainPlayer = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
        target = goal;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTo();
        

        //agent.SetDestination(mainPlayer.transform.position);
        PlayerStats mainPlayerStats = mainPlayer.GetComponent<PlayerStats>();
        cylMove playerController = mainPlayer.GetComponent<cylMove>();
        if (mainPlayerStats!= null)
        {
            if (mainPlayerStats.attackMode)
            {

                if (playerController.focus != null)
                {
                    target = playerController.focus.transform;
                    agent.SetDestination(target.position);
                    float distance = Vector3.Distance(target.position, transform.position);
                    //target = FindClosestEnemy();
                    if (distance <= lookRadius)
                    {
                        //agent.SetDestination(target.transform.position);
                        if (distance <= agent.stoppingDistance)
                        {
                            if (target.GetComponent<CharacterStats>() != null)
                            {
                                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                                CharacterCombat combat = this.GetComponent<CharacterCombat>();
                                if (targetStats != null)
                                {
                                    combat.Attack(targetStats);
                                    FaceTarget();
                                }

                            }
                        }
                    }
                    if (target == null)
                    {
                        target = goal;
                    }
                }

            }
            else
                target = goal;
        }
        FaceTarget();
      

    }
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


    // Update is called once per frame
    void moveTo () {
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
        
         
    }
         
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}


