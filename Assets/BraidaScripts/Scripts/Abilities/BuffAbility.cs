using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/BuffAbility")]
public class BuffAbility : Ability
{
    public float statMultiplier;
    public float timeDuration;
    
    public override void Initialize(GameObject obj)
    {
        if (obj.GetComponent<CharacterCombat>() != null)
        {
            TriggerAbility(obj);
            
        }
        
    }
    public override void TriggerAbility()
    {
        
    }

    public void TriggerAbility(GameObject target)
    {
        
        target.GetComponent<CharacterCombat>().attackSpeed = target.GetComponent<CharacterCombat>().attackSpeed * statMultiplier;
        for (int i = 0; i < BuffManager.instance.characters.Length; i++)
        {
            if (BuffManager.instance.characters[i] == target)
            {
                if (target.GetComponent<PartyStats>().UnderMetalEfect(metal.name)) {
                    Debug.Log("target = character");
                    if (!BuffManager.instance.buffEffect[i])
                    {
                        Debug.Log("Segue");
                        BuffManager.instance.buffEffect[i] = true;
                        Debug.Log(BuffManager.instance.buffEffect[i]);
                        BuffManager.instance.timeDuration[i] = timeDuration;
                        BuffManager.instance.abilities[i] = this;
                    }
                }
                else
                {
                    Debug.Log("Not Under effect");
                }
                
            }
        }
    }
    public void TakeEffect(GameObject target)
    {
        target.GetComponent<CharacterCombat>().attackSpeed = target.GetComponent<CharacterCombat>().attackSpeed / statMultiplier;
    }
}
