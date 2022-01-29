using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;
    
    private void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }
    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        rb.velocity = direction;
    }
}
