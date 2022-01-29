using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private bool hasInteracted = false;
    public UnityEvent OnInteraction;
    
    public void Interact()
    {
        if (hasInteracted) return;

        OnInteraction.Invoke();
        hasInteracted = true;
    }
}
