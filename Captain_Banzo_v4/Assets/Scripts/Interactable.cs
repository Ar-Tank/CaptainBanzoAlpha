using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Message displayed when looking at an interactable
    public string promptMessage;
    // Add or remove an InteractionEvent to this game object
    public bool useEvents;
    
    

    // This will be called from the player
        public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        // No code here
        // Template function for subclasses to override
    }
    
}
