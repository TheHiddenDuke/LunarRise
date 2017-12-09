using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    GameObject mainPlayer;
    public GameObject target = null;
    NavMeshAgent agent;
    public Transform goal;
    public Transform other;
    public AIStats aiStats;
    public CharacterStats targetStats;
    public Transform focus;
    PlayerStats mainPlayerStats;
    CharacterCombat combat;
    




    public float lookRadius = 10f;
    // Use this for initialization
    void Start()
    {
        mainPlayer = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
        focus = goal;
        mainPlayerStats = mainPlayer.GetComponent<PlayerStats>();
        aiStats = this.GetComponent<AIStats>();
        combat = this.GetComponent<CharacterCombat>();

    }

    // Update is called once per frame
    void Update()
    {
        moveTo();
        
        if (aiStats.currentHealth <= 0.1f)       //If player died, set values to null an keep it still while dieing animation happens
        {
            target = null;
            goal = null;
            focus = null;
            aiStats.attacking = false;
            aiStats.underAttack = false;
        }

        

        //cylMove playerController = mainPlayer.GetComponent<cylMove>();
        if (mainPlayerStats != null)
        {
            
            
            if (aiStats.underAttack&&!aiStats.abilityAttack)
            {
                aiStats.attacking = true;
            }
            //if (!aiStats.abilityAttack)
            //{

                if (mainPlayerStats.attacking || aiStats.attacking)
                {
                    if (target == null)
                    {
                        target = FindClosestEnemy();
                    }
                    focus = target.transform;
                    targetStats = target.GetComponent<CharacterStats>();


                    agent.SetDestination(target.transform.position);
                    float distance = Vector3.Distance(target.transform.position, transform.position);
                    
                    if (distance <= lookRadius)
                    {
                    
                    if (distance <= agent.stoppingDistance)
                        {
                        
                        if (targetStats != null)
                            {
                            
                            if (!targetStats.dead)
                            {
                                
                                combat.Attack(targetStats);
                                aiStats.attacking = true;
                                FaceTarget();
                            }
                            }
                            //If the current enemy's life ended, but the main player is not attacking, stop attacking
                            if ((targetStats.currentHealth < 0.1f) && !mainPlayerStats.attacking)
                            {
                                aiStats.attacking = false;
                                focus = mainPlayer.transform;
                                goal = focus;
                                target = null;
                            }

                        }
                    }
                }
                else if (aiStats.abilityAttack)
            {

            }
            else
                {
                
                {
                    targetStats = null;
                    goal = mainPlayer.transform;
                    focus = goal;
                    aiStats.attacking = false;
                }
                    //aiStats.underAttack = false;
                }
            //}
            //
        //}       
            
            
            //target = goal.GetComponent<GameObject>();
        }
        FaceTarget();
      

    }
    
        public GameObject FindClosestEnemy(){
      GameObject[] gos;
      CharacterStats goStats;
      gos = GameObject.FindGameObjectsWithTag("Enemy");
      GameObject closest = null;
      float distance = Mathf.Infinity;
      Vector3 position = transform.position;
      foreach (GameObject go in gos)
      {
          Vector3 diff = go.transform.position - position;
            goStats = go.GetComponent<CharacterStats>();
          float curDistance = diff.sqrMagnitude;
          if (curDistance < distance && (goStats.currentHealth>=0))
          {
              closest = go;
              distance = curDistance;
          }
      }
      return closest;
  }
    void Rest()
    {

    }
     
    void moveTo () {

        if (goal != null)
        {
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
         
    }
         
    void FaceTarget()
    {
        Vector3 direction = (focus.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}


