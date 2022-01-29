using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnExit?.Invoke();
    }
}
