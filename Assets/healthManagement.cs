using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManagement : MonoBehaviour {

    public Slider health;
    public GameObject character;
    
    
    // Use this for initialization
	void Start () {

        health.value = 100;
        

}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (character != null)
        {
            CharacterStats playerStats = character.GetComponent<CharacterStats>();
            health.value = playerStats.currentHealth;
            
        }
        
	}
}
