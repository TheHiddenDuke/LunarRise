using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Abilities/RayCastAbilityMainPlayer")]
public class RayCastAbilityMainPlayer : Ability
{
    public int damage = 1;
    public float range = 50f;
    private RayCastSkillTrigger rcst;
    

    public override void Initialize(GameObject obj)
    {

        rcst = obj.GetComponent<RayCastSkillTrigger>();
        rcst.Initialize();
        rcst.skillDamage = damage;
        rcst.skillRange = range;
        rcst.skillname = aname;
        rcst.character = PlayerManager.instance.player.transform;
        

    }

    public override void TriggerAbility()
    {
        rcst.Triggered = true;

        //rcst.ActivateMainPlayerAbility();
    }
}
