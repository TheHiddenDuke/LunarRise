using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public AbilityButtonInfo abilityButton= null;
    public MetalInfo metalButton = null;
    public BuffButtonInfo buffButton = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void OnAction(string input)
    {
        if ((buffButton = GetComponent<DragAndDropCell>().GetItem().GetComponent<BuffButtonInfo>()) != null)
        {
            if (buffButton.ability.available)
            {
                GetComponent<AbilityCoolDown>().ability = buffButton.ability;
                //PlayerManager.instance.player.GetComponent<RayCastSkillTrigger>().Triggered = true;
                GetComponent<AbilityCoolDown>().Initialize(input, buffButton.character);
                Debug.Log("Pegando o certo");
            }
            else
            {
                Debug.Log("unavailable ability");
            }
        }else
        if ((abilityButton = GetComponent<DragAndDropCell>().GetItem().GetComponent<AbilityButtonInfo>()) != null)
        {
            if (abilityButton.ability.available)
            {
                GetComponent<AbilityCoolDown>().ability = abilityButton.ability;
                //PlayerManager.instance.player.GetComponent<RayCastSkillTrigger>().Triggered = true;
                GetComponent<AbilityCoolDown>().Initialize(input, PlayerManager.instance.player);
            }
            else
            {
                Debug.Log("unavailable ability");
            }
        }else

        if ((metalButton = GetComponent<DragAndDropCell>().GetItem().GetComponent<MetalInfo>()) != null)
        {
            if (metalButton.amount!=0)
            {
                metalButton.metal.Use(metalButton.character.name);
                //Debug.Log("metal ok until here");
                GetComponent<DragAndDropCell>().GetItem().GetComponent<MetalInfo>().amount--;
            }
            else
            {
                Debug.Log("not enough metal");
            }
        }
    }
}
