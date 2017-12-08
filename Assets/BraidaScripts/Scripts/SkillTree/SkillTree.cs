using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {

    //public RayCastAbility[] activeAbilities = new RayCastAbility[4];
    //public StatsAbilities[] passiveAbilities = new StatsAbilities[4]; 
    public Button[] skillbuttons = new Button[2];

    public float totalSkillPoints = 0;

    public GameObject skillTreeCharacter;
    void Start () {
		
	}
	
	
	void Update () {
        if(totalSkillPoints == 0)
        {
            for (int i = 0; i < skillbuttons.Length; i++)
            {
                skillbuttons[i].GetComponent<Button>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < skillbuttons.Length; i++)
            {
                skillbuttons[i].GetComponent<Button>().enabled = true;
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

    public void StatAbility(StatsAbilities statAbility)
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
}
