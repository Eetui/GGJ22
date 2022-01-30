using UnityEngine;

public class FlipX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;

    public void Toggle()
    {
        sr.flipX = !sr.flipX;
    }
} 
