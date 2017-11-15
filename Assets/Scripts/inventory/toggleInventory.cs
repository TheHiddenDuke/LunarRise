using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleInventory : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("Interacting wiht " + gameObject.activeSelf);
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
