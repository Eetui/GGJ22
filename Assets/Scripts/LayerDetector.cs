using UnityEngine;

public class LayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layerToDetect;
    [SerializeField] private float distance;
    
    public bool Detect()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distance, layerToDetect);
    }
}
