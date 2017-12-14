﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {

    //public RayCastAbility[] activeAbilities = new RayCastAbility[4];
    //public StatsAbilities[] passiveAbilities = new StatsAbilities[4]; 
    public Button[] skillbuttons = new Button[3];
    public PartyStats infoStats;
    public Text[] playerInfo = new Text[6];
    public float totalSkillPoints = 0;

    public GameObject skillTreeCharacter;
    void Start () {
		
	}
	
	
	void Update () {
        if (skillTreeCharacter != null)
        {
            if (skillTreeCharacter.GetComponent<PartyStats>() != null)
            {
                infoStats = skillTreeCharacter.GetComponent<PartyStats>();

                playerInfo[0].text = infoStats.damage.getValue().ToString();
                playerInfo[1].text = infoStats.armor.getValue().ToString();
                playerInfo[2].text = infoStats.currentlvl.ToString();
                playerInfo[3].text = infoStats.currentXp.ToString();
                playerInfo[4].text = infoStats.currentHealth.ToString();
                playerInfo[5].text = infoStats.skillPoints.ToString();
                totalSkillPoints = infoStats.skillPoints;

                if (totalSkillPoints == 0)
                {

                    for (int i = 0; i < skillbuttons.Length; i++)
                    {
                        AbilityButtonInfo skillAbility = skillbuttons[i].GetComponent<AbilityButtonInfo>();
                        if (skillAbility != null)
                        {
                            skillbuttons[i].interactable = false;
                            /*if (skillAbility.available == true)
                            {
                                skillbuttons[i].interactable = true;
                            }
                            else
                            {
                                skillbuttons[i].interactable = false;
                            }*/
                            //skillbuttons[i].enabled = false;
                        }
                    }

                }
                if (totalSkillPoints != 0)
                {

                    for (int i = 0; i < skillbuttons.Length; i++)
                    {
                        AbilityButtonInfo skillAbility = skillbuttons[i].GetComponent<AbilityButtonInfo>();
                        if (skillAbility != null)
                        {
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
        }
        }

    public void AllowAbility(RayCastAbilityAI activeAbility)
    {
        if (activeAbility.available == false)
        {
            if ((activeAbility.requirement == null) || (activeAbility.requirement.available == true))
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                activeAbility.level++;
                activeAbility.available = true;
                Debug.Log(activeAbility.aname);
            }
        }
        else
        {
            if (activeAbility.level < 10)
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                activeAbility.level++;
                activeAbility.damage = Mathf.RoundToInt(activeAbility.damage * 1.2f);
                Debug.Log(activeAbility.damage);
            }
        }
        }
    public void AllowAbility(RayCastAbilityMainPlayer activeAbility)
    {
        if (activeAbility.available == false)
        {
            if ((activeAbility.requirement == null) || (activeAbility.requirement.available == true))
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                activeAbility.level++;
                activeAbility.available = true;
                Debug.Log(activeAbility.aname);
            }
        }
        else
        {
            if (activeAbility.level < 10)
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                activeAbility.level++;
                activeAbility.damage = Mathf.RoundToInt(activeAbility.damage * 1.2f);
                Debug.Log(activeAbility.damage);
            }
        }
    }
    public void AllowAbility(BuffAbility activeAbility)
    {
        if (activeAbility.available == false)
        {
            if ((activeAbility.requirement == null) || (activeAbility.requirement.available == true))
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                activeAbility.level++;
                activeAbility.available = true;
                Debug.Log(activeAbility.aname);
            }
        }
        else
        {
            if (activeAbility.level < 10)
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                activeAbility.level++;
                activeAbility.statMultiplier = activeAbility.statMultiplier+0.2f;
                Debug.Log(activeAbility.statMultiplier);
            }
        }
    }

    public void StatAbilityDamage(StatsAbilities statAbility)
    {
        if (statAbility.available == false)
        {
            totalSkillPoints--;
            skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
            statAbility.available = true;
            statAbility.level++;
            CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
            characterStats.damage.setValue(Mathf.RoundToInt((characterStats.damage.getValue() * statAbility.statMultiplier)));
            Debug.Log(skillTreeCharacter.name + " " + characterStats.damage.getValue());
        }
        else
        {
            if (statAbility.level < 10)
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                statAbility.level++;
                statAbility.statMultiplier = statAbility.statMultiplier + 0.2f;
                CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
                characterStats.damage.setValue(Mathf.RoundToInt((characterStats.damage.getValue() * statAbility.statMultiplier)));
                Debug.Log(skillTreeCharacter.name + " " + characterStats.damage.getValue());
                Debug.Log(statAbility.statMultiplier);
            }
        }
    }
    public void StatAbilityArmor(StatsAbilities statAbility)
    {
        if (statAbility.available == false)
        {
            totalSkillPoints--;
            skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
            statAbility.available = true;
            statAbility.level++;
            CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
            characterStats.armor.setValue(Mathf.RoundToInt((characterStats.armor.getValue() * statAbility.statMultiplier)));
            Debug.Log(skillTreeCharacter.name + " " + characterStats.armor.getValue());
        }
        else
        {
            if (statAbility.level < 10)
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                statAbility.level++;
                statAbility.statMultiplier = statAbility.statMultiplier + 0.2f;
                CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
                characterStats.armor.setValue(Mathf.RoundToInt((characterStats.armor.getValue() * statAbility.statMultiplier)));
                Debug.Log(skillTreeCharacter.name + " " + characterStats.armor.getValue());
                Debug.Log(statAbility.statMultiplier);
            }
        }
    }
    public void StatAbilityHealth(StatsAbilities statAbility)
    {
        if (statAbility.available == false)
        {
            totalSkillPoints--;
            skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
            statAbility.available = true;
            statAbility.level++;
            CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
            if (characterStats.currentHealth == characterStats.maxHealth)
            {
                characterStats.maxHealth = (Mathf.RoundToInt((characterStats.maxHealth * statAbility.statMultiplier)));
                characterStats.currentHealth = characterStats.maxHealth;
            }
            else
            {
                characterStats.maxHealth = (Mathf.RoundToInt((characterStats.maxHealth * statAbility.statMultiplier)));
            }
            Debug.Log(skillTreeCharacter.name + " " + characterStats.maxHealth);
        }
        else
        {
            if (statAbility.level < 10)
            {
                totalSkillPoints--;
                skillTreeCharacter.GetComponent<PartyStats>().skillPoints--;
                statAbility.level++;
                statAbility.statMultiplier = statAbility.statMultiplier + 0.2f;
                CharacterStats characterStats = skillTreeCharacter.GetComponent<CharacterStats>();
                if (characterStats.currentHealth == characterStats.maxHealth)
                {
                    characterStats.maxHealth = (Mathf.RoundToInt((characterStats.maxHealth * statAbility.statMultiplier)));
                    characterStats.currentHealth = characterStats.maxHealth;
                }
                else
                {
                    characterStats.maxHealth = (Mathf.RoundToInt((characterStats.maxHealth * statAbility.statMultiplier)));
                }
                Debug.Log(skillTreeCharacter.name + " " + characterStats.maxHealth);
                
            }
        }
    }

}
