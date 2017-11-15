using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.rotation.x <= 0)
        {
            transform.Rotate(1f, 0, 0);
        }
        else if (transform.rotation.x>0)
        {
            transform.Rotate(0.1f, 0, 0);
        }
    }
}
