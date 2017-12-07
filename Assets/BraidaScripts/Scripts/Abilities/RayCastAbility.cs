using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Abilities/RayCastAbility")]
public class RayCastAbility : Ability
{
    public int damage = 1;
    public float range = 50f;
    private RayCastSkillTrigger rcst;
    public string allyName;

    public override void Initialize(GameObject obj)
    {
         
        rcst = obj.GetComponent<RayCastSkillTrigger>();
        rcst.Initialize();
        rcst.skillDamage = damage;
        rcst.skillRange = range;
        rcst.skillname = aname;
        GameObject[] allies = rcst.allies;
        Debug.Log("initalize ability");
        foreach (GameObject ally in allies)
        {
            if (ally != null)
            {
                if (ally.name == allyName)
                {
                    rcst.character = ally.transform;
                    rcst.aIController = ally.GetComponent<AIController>();
                    rcst.agent = ally.GetComponent<NavMeshAgent>();
                    Debug.Log("right ally " + allyName);

                }
            }
        }
    
    }

    public override void TriggerAbility()
    {
        rcst.Triggered = true;
        
        //rcst.Activate();
    }
}
