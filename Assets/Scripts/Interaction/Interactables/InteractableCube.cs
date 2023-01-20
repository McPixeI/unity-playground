using UnityEngine;

public class InteractableCube : Interactable
{
    protected override void Interact()
    {
        Debug.Log("interacted with " + gameObject.name);
    }
}
