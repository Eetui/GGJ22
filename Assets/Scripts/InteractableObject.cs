using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private bool hasInteracted = false;
    public UnityEvent OnInteraction;
    
    public void Interact()
    {
        if (hasInteracted) return;
        Debug.Log("Boom");
        OnInteraction.Invoke();
        hasInteracted = true;
    }
}
