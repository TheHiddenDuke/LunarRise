using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {

    //public RayCastAbility[] activeAbilities = new RayCastAbility[4];
    //public StatsAbilities[] passiveAbilities = new StatsAbilities[4]; 
    public Button[] skillbuttons = new Button[3];

    public float totalSkillPoints = 0;

    public GameObject skillTreeCharacter;
    void Start () {
		
	}
	
	
	void Update () {
        if(totalSkillPoints == 0)
        {
            for (int i = 0; i < skillbuttons.Length; i++)
            {
                skillbuttons[i].interactable = false;
            }
            
        }
        else
        {
            for (int i = 0; i < skillbuttons.Length; i++)
            {
                AbilityButtonInfo skillAbility = skillbuttons[i].GetComponent<AbilityButtonInfo>();
                if(skillAbility!=null){ 
                if ((skillAbility.requirement == null) || (skillAbility.available == true) || (skillAbility.requirement.available))
                {
                    skillbuttons[i].interactable = true;
                }
                else
                {
                    skillbuttons[i].interactable = false;
                }
            }
            }
        }
		
	}

    public void AllowAbility(RayCastAbility activeAbility)
    {
        if (activeAbility.available == false)
        {
            if ((activeAbility.requirement == null) || (activeAbility.requirement.available == true))
            {
                totalSkillPoints--;
                activeAbility.available = true;
                Debug.Log(activeAbility.aname);
            }
        }
        }

    public void StatAbilityDamage(StatsAbilities statAbility)
    {
        if (statAbility.available == false)
        {
            totalSkillPoints--;
            statAbility.available = true;
            CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
            characterStats.damage.setValue(Mathf.RoundToInt((characterStats.damage.getValue() * statAbility.statMultiplier)));
            Debug.Log(skillTreeCharacter.name + " " + characterStats.damage.getValue());
        }
        }
    public void StatAbilityArmor(StatsAbilities statAbility)
    {
        if (statAbility.available == false)
        {
            totalSkillPoints--;
            statAbility.available = true;
            CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
            characterStats.armor.setValue(Mathf.RoundToInt((characterStats.armor.getValue() * statAbility.statMultiplier)));
            Debug.Log(skillTreeCharacter.name + " " + characterStats.armor.getValue());
        }
    }
    public void StatAbilityHealth(StatsAbilities statAbility)
    {
        if (statAbility.available == false)
        {
            totalSkillPoints--;
            statAbility.available = true;
            CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
            characterStats.maxHealth = (Mathf.RoundToInt((characterStats.maxHealth * statAbility.statMultiplier)));
            Debug.Log(skillTreeCharacter.name + " " + characterStats.maxHealth);
        }
    }

}
