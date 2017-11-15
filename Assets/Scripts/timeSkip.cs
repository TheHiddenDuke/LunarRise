using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeSkip : MonoBehaviour {
    public float startTime;
    // Use this for initialization
    void Start () {
        transform.Rotate(0, startTime, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("timeSkip"))
        {
            transform.Rotate(0, 1f, 0);
        }
    }
}
