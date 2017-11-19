using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControllerKeyButton : MonoBehaviour
{
    PlayerMotor motor;
    public Interactable focus= null;
    Camera cam;
        void Start()
    {
        cam = Camera.main;
    
    }

   
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        if (Input.GetMouseButtonDown(1))
        {
            RemoveFocus();
        }
        if (Input.GetMouseButtonDown(0))
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
    void SetFocus( Interactable newFocus)
    {
        focus = newFocus;
        //motor.FollowTarget(focus);
    }

    void RemoveFocus()
    {
        focus = null;
        //motor.StopFollowingTarget();
    }
}