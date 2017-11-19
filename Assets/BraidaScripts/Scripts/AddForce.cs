using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {
    public float ForceValue = 100f;

    Rigidbody rgdb;
	// Use this for initialization
	void Start () {
        rgdb = GetComponent<Rigidbody>();
	}
	void OnMouseDown()
    {
        rgdb.AddForce(transform.right * ForceValue, ForceMode.Acceleration);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
