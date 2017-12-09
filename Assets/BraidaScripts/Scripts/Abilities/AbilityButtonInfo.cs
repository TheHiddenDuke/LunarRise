using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButtonInfo : MonoBehaviour {
    public Ability ability;
    public Ability requirement;
    public bool available = false;


	// Use this for initialization
	void Start () {
        requirement = ability.requirement;
    }
	
	// Update is called once per frame
	void Update () {
        available = ability.available;
	}
}
