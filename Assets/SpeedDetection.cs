using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDetection : MonoBehaviour {
    public Transform newTransform;
    public Vector3 oldTransform;
    public float time = 0;
    public bool speed=false;
    // Use this for initialization
    void Start () {
        newTransform = GetComponent<Transform>();
        oldTransform = newTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (time > 0)
        {
            if (oldTransform != newTransform.position)
            {
                speed = true;
                oldTransform = newTransform.position;
                time = 0;
                

            }
            else
            {
                
                speed = false;
            }
        }
        time = time + Time.deltaTime;
       
       
	}
}
