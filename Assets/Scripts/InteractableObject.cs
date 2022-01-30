using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private bool canInteractMultipleTimes;
    private bool hasInteracted = false;
    public UnityEvent OnInteraction;
    
    public void Interact()
    {
        if (hasInteracted && !canInteractMultipleTimes) return;

        OnInteraction.Invoke();
        hasInteracted = true;
    }
}
