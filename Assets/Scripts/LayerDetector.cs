using System;
using UnityEngine;

public class LayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layerToDetect;
    [SerializeField] private float distance;

    [Header("Gizmos")] [SerializeField] private bool drawGizmos;
    [SerializeField] private Color32 gizmosColor = Color.red;
    
    public bool Detect()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distance, layerToDetect);
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;
        
        Gizmos.color = gizmosColor;
        var pos = transform.position;
        Gizmos.DrawRay(pos, new Vector3(0,  -distance, 0));

    }
}
