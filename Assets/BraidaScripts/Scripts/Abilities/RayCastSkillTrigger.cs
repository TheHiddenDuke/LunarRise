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
            //Keep waiting untill player choose a target
            if (Input.GetMouseButtonDown(0) || (target != null))
            {
                //Keep calli Activate method untillthe AI attacks the enemy
                if (!attackHappened) 
                {
                    Activate();
                    
                    
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
                    if (distance <= skillRange+1)
                    {

                        if (targetStats != null)
                        {
                            targetStats.TakeDamage(skillDamage);
                            Debug.Log(target.name + " received" + skillDamage.ToString() + " from " + skillname);
                            attackHappened = true;
                            aIController.target = null;
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
