using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManagement : MonoBehaviour {

    public Slider health;
    
    
    
    // Use this for initialization
	void Start () {

        health.value = 100;
        

}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        GameObject player = GameObject.Find("Player");
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        health.value = playerStats.currentHealth;
        
	}
}
