using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour {
    public Ability[] abilities = new Ability[3]; 
	// Use this for initialization
	void Start () {
		for(int i=0; i<abilities.Length; i++)
        {
            abilities[i].available = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
