using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour {
    
    public float distance;
    public Transform player;
    public GameObject target;

    private void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y + distance, player.position.z - distance);
        transform.eulerAngles = new Vector3(player.eulerAngles.x + 45f,player.eulerAngles.y,0);
    }

    void FixedUpdate()
    {


        
        //transform.LookAt(target.transform);

        /*
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z - distance);
        transform.eulerAngles = new Vector3(Input.GetAxis("Horizontal"), player.eulerAngles.y, Input.GetAxis("Vertical"));
        */

    }
}
