using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMouse : MonoBehaviour {
    public LayerMask movement;
    
    PlayerStats playerStats;
    Camera cam;
    PlayerMotor motor;
    public Interactable focus;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, movement))
            {
                Debug.Log("Something");
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interectable = hit.collider.GetComponent<Interactable>();
                if (interectable != null)
                {
                    SetFocus(interectable);
                }
            }
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
            //attackMode = true;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);
        
    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        //attackMode = false;
        motor.StopFollowingTarget();
    }
}
