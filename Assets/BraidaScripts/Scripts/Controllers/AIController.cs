using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    GameObject mainPlayer;
    public GameObject target;
    NavMeshAgent agent;
    public Transform goal;
    public Transform other;
    AIStats aiStats;
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
    void FixedUpdate()
    {
        moveTo();
        

        //agent.SetDestination(mainPlayer.transform.position);
        
        cylMove playerController = mainPlayer.GetComponent<cylMove>();
        if (mainPlayerStats!= null)
        {
            target = FindClosestEnemy();


            if (target != null)
            {
                if (mainPlayerStats.attacking || aiStats.attacking)
                {

                    focus = target.transform;
                    targetStats = target.GetComponent<CharacterStats>();


                    agent.SetDestination(target.transform.position);
                    float distance = Vector3.Distance(target.transform.position, transform.position);
                    if (distance <= lookRadius)
                    {
                        if (distance <= agent.stoppingDistance)
                        {
                            if (target.GetComponent<CharacterStats>() != null)
                            {
                                if (targetStats != null)
                                {
                                    combat.Attack(targetStats);
                                    aiStats.attacking = true;
                                    FaceTarget();
                                }


                            }
                        }
                    }
                }
            }
            else
            {
                targetStats = null;
                focus = goal;
                aiStats.attacking = false;
            }
                
            
            
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
        Vector3 direction = (focus.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}


