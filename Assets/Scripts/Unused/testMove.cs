using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    Vector3 destination;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destination = agent.destination;
    }

    // Update is called once per frame
    void Update () {
	   if (Vector3.Distance (destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
	}
}
