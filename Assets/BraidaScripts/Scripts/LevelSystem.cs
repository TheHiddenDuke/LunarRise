using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {
    #region Singleton
    public static LevelSystem instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int gainedXP = 0;
    public GameObject[] partyMembers = new GameObject[3];
    public CharacterStats[] partyStats = new CharacterStats[3];
	// Use this for initialization
	void Start () {
		for(int i = 0; i < partyMembers.Length; i++)
        {
            partyStats[i] = partyMembers[i].GetComponent<CharacterStats>();            
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(gainedXP != 0)
        {
            for (int i = 0; i < partyMembers.Length; i++)
            {
                partyStats[i].currentXp = gainedXP/3;
                if (partyStats[i].currentXp >= partyStats[i].nextLevelXp)
                {
                    partyStats[i].currentlvl++;
                    partyStats[i].skillPoints++;
                    partyStats[i].currentXp = partyStats[i].currentXp - partyStats[i].nextLevelXp;
                    partyStats[i].nextLevelXp = 100 * (partyStats[i].currentlvl + 1) * (partyStats[i].currentlvl + 1);
                }
            }
            Debug.Log(gainedXP);
            gainedXP = 0;
        }

	}
    
}
