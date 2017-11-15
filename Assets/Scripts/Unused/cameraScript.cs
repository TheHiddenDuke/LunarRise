using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = GetComponent<Camera>();
        yaw += speedH * Input.GetAxis("Mouse X");

        
        if(cam.transform.eulerAngles.x < 45f)
        {
            
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        if (cam.transform.eulerAngles.x < 70f && cam.transform.eulerAngles.x > 45f)
        {
            pitch = 44.5f;
        }
        else if (cam.transform.eulerAngles.x > 270f)
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        else
        {
            //pitch--;
        }
        
        

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}
