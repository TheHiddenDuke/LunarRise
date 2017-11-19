using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float turnSpeed= 10f;
    bool isRotating;
    Vector3 mouseOrigin;
    // Use this for initialization
    /*private void LateUpdate()
    {
        transform.position = target.position - offset;
        transform.LookAt(target.position + Vector3.up * pitch);

        //transform.RotateAround(target.position, Vector3.up, currentYaw);
    }*/
    
    // Update is called once per frame
    void Update () {
        
       
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isRotating = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }
        else
        {
            transform.position = target.position - offset;
            transform.LookAt(target.position + Vector3.up * pitch);
        }
    }
}
