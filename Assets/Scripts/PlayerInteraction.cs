using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool canInteract;
    private IInteractable interactable;
    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E)) 
        {
            if (interactable == null) return;
            interactable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable _interactable)) 
        {
            interactable = _interactable;
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        interactable = null;
    }
}