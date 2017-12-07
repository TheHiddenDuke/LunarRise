using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RayCastSkillTrigger : MonoBehaviour {
    Camera cam;
    public string skillname;
    public int skillDamage = 1;
    public float skillRange = 50f;
    public string allyname;
    public Transform character;
    public CharacterStats targetStats;
    public Transform target = null;
    public bool attackHappened = false;
    public bool Triggered = false;
    public GameObject[] allies = new GameObject[3];
    public AIController aIController;
    public NavMeshAgent agent;
    public float distance;


    public void Initialize()
    {
        cam = Camera.main;
        Debug.Log("initialize ok");
        //AIController aIController = character.GetComponent<AIController>();
    }
    private void Update()
    {
        if (Triggered)
        {
            if (!attackHappened)
            {
                if (Input.GetMouseButtonDown(0) || (target != null))
                {
                    Debug.Log("Raycast here");
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        Debug.Log("RayCasting ok1");
                        if (hit.transform.GetComponent<EnemyController>() != null)
                        {
                            Debug.Log(hit.transform.name + " hitting okay");
                            /*if (target == null)
                            {
                                target = hit.transform;
                            }*/
                            //else
                            //{

                            target = hit.transform;
                            if (target != null) {
                                //AIController aIController = character.GetComponent<AIController>();
                                //agent = character.GetComponent<NavMeshAgent>();
                                aIController.focus = target;
                                aIController.target = target.GetComponent<GameObject>();
                                aIController.goal = target;
                                //aIController.aiStats.abilityAttack = true;
                                //agent.SetDestination(target.transform.position);
                                targetStats = hit.transform.GetComponent<CharacterStats>();
                                distance = Vector3.Distance(target.transform.position, character.transform.position);
                                if (distance <= skillRange+1.1f)
                                {
                                    
                                    if (targetStats != null)
                                    {
                                        targetStats.TakeDamage(skillDamage);
                                        Debug.Log(target.name + " received" + skillDamage.ToString() + " from " + skillname);
                                        attackHappened = true;
                                        //aIController.aiStats.abilityAttack = false;
                                        Triggered = false;
                                        
                                    }
                                    //}
                                }
                                //}

                            }
                            else
                            {
                                aIController.goal = PlayerManager.instance.player.transform;
                                aIController.focus = aIController.goal;
                            }
                        }
                    }

                    /*if ((target != null) && !attackHappened)
                    {
                        Activate();
                    }*/
                }
            }
        }
        
    }
    // Update is called once per frame
    public void Activate()
    {
        Debug.Log("Activate ok");

       
        if (Input.GetButtonDown("TestButton")) 
        {
            Debug.Log("RayCasting ok");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log("RayCasting ok1");
                if (hit.transform.GetComponent<EnemyController>() != null) {
                    if (target == null)
                    {
                        target = hit.transform;
                    }
                    else { 
                        NavMeshAgent agent = character.GetComponent<NavMeshAgent>();
                        agent.SetDestination(target.transform.position);
                    targetStats = hit.transform.GetComponent<CharacterStats>();
                    float distance = Vector3.Distance(target.transform.position, character.transform.position);
                    if (distance <= skillRange)
                    {
                        if (targetStats != null)
                        {
                            targetStats.TakeDamage(skillDamage);
                                Debug.Log(target.name + " received" + skillDamage.ToString() + " from " + skillname);
                                attackHappened = true;
                        }

                    }
                }

                    
            }
            }
        }
    }
}
