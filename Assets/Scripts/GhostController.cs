using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
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
        var vel = rb.velocity;
        rb.velocity = direction;
        
        if (vel.x < -0.1) 
        {
            sr.flipX = true;
        }
        else if(vel.x > 0.1)
        {
            sr.flipX = false;
        }
    }
}
