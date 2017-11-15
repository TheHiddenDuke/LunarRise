using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocused = false;
    bool hasInteracted = false;

    Transform player;


    public virtual void Interact()
    {
        //This method is meant to be overwritten
        Debug.Log("Interacting wiht " + transform.name);
    }


    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }    
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;

    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
