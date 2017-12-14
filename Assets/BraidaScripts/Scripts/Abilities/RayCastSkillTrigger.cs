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
    public MetalItem metal;
    public Transform character;
    public CharacterStats targetStats;
    public Transform target = null;
    public bool attackHappened = false;
    public bool Triggered = false;
    public GameObject[] allies = new GameObject[3];
    /*the index of the metal effect vector on PartyStats corresponding to the metal name vector, also on PartyStats, that has the same name
     * as the required metal for the ability is stored here when the trigger is initialized
     * that way there is no need to search the index on each uptade
    */
    public int metalIndex = 0;
    public AIController aIController;
    public PartyStats partyStats;
    public int skillframes;
    public NavMeshAgent agent;
    public float distance;

    public Animator anim;
    public void Initialize()
    {
        cam = Camera.main;
        Debug.Log("initialize ok");
        
    }
    private void Update()
    {
        if (Triggered)
        {
            if (character != null) {
                anim = character.GetComponentInChildren<Animator>();
                if (metal != null)
                {
                    if (character == PlayerManager.instance.player.transform)
                    {
                        anim = character.GetComponentInChildren<Animator>();
                        if (partyStats.metalEffect[metalIndex])
                        {
                            partyStats.abilityAttack = true;
                            if (Input.GetMouseButtonDown(0) || (target != null))
                            {
                                //Keep calling Activate method untill the player attacks the enemy
                                if (!attackHappened)
                                {
                                    
                                    ActivateMainPlayerAbility();
                                }
                            }

                        }
                        else
                        {
                            Debug.Log(character.name + " Not in metal state");
                        }

                    }
                    else
                    {
                        if (partyStats.metalEffect[metalIndex])
                        {
                            if (Input.GetMouseButtonDown(0) || (target != null))
                            {
                                //Keep calling Activate method untill the AI attacks the enemy
                                if (!attackHappened)
                                {
                                   
                                    Activate();
                                }
                            }

                        }
                        else
                        {
                            Debug.Log(character.name + " Not in metal state");
                        }
                    }
                }
                else
                {
                    //Keep waiting untill player choose a target
                    if (Input.GetMouseButtonDown(0) || (target != null))
                    {
                        //Keep calli Activate method untillthe AI attacks the enemy
                        if (!attackHappened)
                        {
                            if (character == PlayerManager.instance.player.transform)
                            {
                                ActivateMainPlayerAbility();
                            }
                            else
                            {
                                Activate();
                            }

                        }
                    }

                }
        }
    }
        
    }
    public void ResetTrigger()
    {
        character = null;
        targetStats = null; ;
        target = null;
        attackHappened = false;
        Triggered = false;
        aIController= null;
        agent = null;
        distance = 0;

}
    public void ActivateMainPlayerAbility()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log("RayCasting ok1");
            if (hit.transform.GetComponent<EnemyController>() != null)
            {
                
                
                target = hit.transform;
                if (target != null)
                {   targetStats = hit.transform.GetComponent<CharacterStats>();
                    distance = Vector3.Distance(target.transform.position, character.transform.position);
                    if (distance <= skillRange + 1)
                    {

                        if (targetStats != null)
                        {
                            targetStats.TakeDamage(skillDamage, this.name);
                            anim.SetTrigger("SuperKick");
                            Debug.Log(target.name + " received" + skillDamage.ToString() + " from " + skillname);
                            attackHappened = true;
                            partyStats.abilityAttack = false;
                            ResetTrigger();
                           

                        }
                        
                        //}
                    }
                    else
                    {
                        Debug.Log("Out of range");
                        ResetTrigger();
                    }
                    //}

                }
                
            }
            else
            {
                Debug.Log("Desistiu da skill");
                ResetTrigger();
                partyStats.abilityAttack = false;
            }
        }
        

    }
    // Update is called once per frame
    public void Activate()
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log("RayCasting ok1");
            if (hit.transform.GetComponent<EnemyController>() != null)
            {
                aIController.aiStats.abilityAttack = true;
                Debug.Log(hit.transform.name + " hitting okay");


                target = hit.transform;
                if (target != null)
                {   //Set focus and goal as the enemy so the ally moves towards the enemy using moveTo function on AIController
                    aIController.focus = target;
                    aIController.goal = target;
                    //Set enemy as the AIs target
                    Debug.Log("Target Setted ok");
                    aIController.target = target.GetComponent<GameObject>();
                    targetStats = hit.transform.GetComponent<CharacterStats>();
                    distance = Vector3.Distance(target.transform.position, character.transform.position);
                    if (distance <= skillRange+2)
                    {

                        if (targetStats != null)
                        {
                            targetStats.TakeDamage(skillDamage, this.name);
                            anim.SetTrigger("SuperPunch");
                            Debug.Log(target.name + " received" + skillDamage.ToString() + " from " + skillname);
                            attackHappened = true;
                            aIController.target = null;
                            aIController.abilityRecuperationTime = skillframes*Time.deltaTime;
                            aIController.aiStats.abilityAttack = false;
                            ResetTrigger();

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

    }
}
