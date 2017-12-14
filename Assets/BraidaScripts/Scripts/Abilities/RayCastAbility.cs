using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Abilities/RayCastAbility")]
public class RayCastAbilityAI : Ability
{
    public int damage = 1;
    public float range = 50f;
    private RayCastSkillTrigger rcst;
    public string allyName;
    public int skillframes;

    public override void Initialize(GameObject obj)
    {
         
        rcst = obj.GetComponent<RayCastSkillTrigger>();
        rcst.Initialize();
        rcst.skillDamage = damage;
        rcst.skillRange = range;
        rcst.skillname = aname;
        rcst.skillframes = skillframes;
        rcst.metal = this.metal;
        GameObject[] allies = PlayerManager.instance.partyAllies;
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
                    rcst.partyStats = ally.GetComponent<PartyStats>();
                    for (int i = 0; i < ally.GetComponent<PartyStats>().metalEffect.Length; i++)
                    {
                        if ((ally.GetComponent<PartyStats>().metalName[i] == metal.name))
                        {
                            rcst.metalIndex = i;

                        }
                    }

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
