using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyStats : CharacterStats {

    public bool[] metalEffect = new bool[2];
    public string[] metalName = new string[2];
    public int currentXp = 0;
    public int currentlvl = 1;
    public int nextLevelXp = 100;
    public int skillPoints = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GainMetalEffect(string metalname)
    {
        for(int i =0; i<metalName.Length; i++)
        {
            if(metalName[i] == metalname)
            {
                metalEffect[i] = true;
            }
        }
    }
    public void LoseMetalEffect(string metalname)
    {
        for (int i = 0; i < metalName.Length; i++)
        {
            if (metalName[i] == metalname)
            {
                metalEffect[i] = false;
            }
        }
    }
}
