using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camAnchor : MonoBehaviour {

    public Transform player;
    public float baseSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 120.0f;
    private Vector3 yaw;
    public float speedH = 2.0f;
    public float runSpeed = 10.0f;
    private float speed;
    private float lockPos = 0;

    CursorLockMode mouseCursor;

    private Vector3 moveDirection = Vector3.zero;


    void Update () {
        transform.position = player.position;
        transform.eulerAngles = new Vector3 (transform.eulerAngles.x,player.eulerAngles.y,player.eulerAngles.z);
	
    



    
    
    
        
        if (Input.GetButton("Run"))
        {
            speed = runSpeed;
        }
        else
        {
            speed = baseSpeed;
        }

        Cursor.lockState = mouseCursor;
        mouseCursor = CursorLockMode.Confined;
        yaw = transform.eulerAngles;
        yaw.z = 0;
        transform.eulerAngles = yaw;

        if (!Input.GetButton("Fire2"))
        {
            transform.Rotate(0, Input.GetAxis("Rotate") * rotateSpeed * Time.deltaTime, 0);
        }



        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {

            if (!Input.GetButton("Fire2"))
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                Cursor.visible = true;

            }
            else if (Input.GetButton("Fire2"))
            {
                Cursor.visible = false;

                moveDirection = new Vector3(Input.GetAxis("HorizontalMouse2"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }


        }
        if (Input.GetButton("Fire2"))
        {
            yaw.z = 0f;
            yaw.y += speedH * Input.GetAxis("Mouse X");
            yaw.x -= speedH * Input.GetAxis("Mouse Y");
            transform.eulerAngles = yaw;
        }


        moveDirection.y -= gravity * Time.deltaTime;
            
    }
}

