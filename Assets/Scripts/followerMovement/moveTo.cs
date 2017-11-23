using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTo : MonoBehaviour {

    // Use this for initialization
    public Transform goal;
    public Transform other;
    


    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        float dist = Vector3.Distance(goal.position, transform.position);
        if (dist > 5f)
        {
            float distOther = Vector3.Distance(other.position, transform.position);
            /*
            if (distOther < 2f)
            {
                transform.position = transform.position;
            }*/
            agent.destination = goal.position;
        }
        else
        {
            agent.destination = transform.position; 
        }
        
         
    }
}
