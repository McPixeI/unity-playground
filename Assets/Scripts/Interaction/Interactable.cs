using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Message displayed to player when looking at an interactable
    public string promptMessage;

    // Function called by the player object
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        // Template function to be overriden by subclasses
    }
}
