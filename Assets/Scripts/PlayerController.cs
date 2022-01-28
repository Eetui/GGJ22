using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float coyote;
    private float coyoteTimer;
    private bool hasJumped;
    [SerializeField] private float jumpBuffer;
    private float jumpBufferTimer;
    private bool hasJumpBuffer;
    private float lastJumpTime;

    [Header("Ground checking")]
    [SerializeField] private List<LayerDetector> groundLayerDetectors;
    private bool isGrounded;
    [SerializeField] private float ignoreGroundedFor;

    private void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal") * speed, 0);
        
        CheckIfGrounded();
        CalculateCoyote();
        CalculateJumpBuffer();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.Space) && coyoteTimer > 0)
        {
            Jump();
        }

        if (isGrounded) hasJumped = false;
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void CalculateJumpBuffer()
    {
        if (isGrounded && hasJumpBuffer)
        {
            Jump();
        }
        
        if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferTimer = jumpBuffer;
        }

        if (jumpBufferTimer < 0) return;
        
        jumpBufferTimer -= Time.deltaTime;
        hasJumpBuffer = jumpBufferTimer > 0;
    }

    private void CalculateCoyote()
    {
        if (isGrounded)
        {
            coyoteTimer = coyote;
        }
        else if (hasJumped)
        {
            coyoteTimer = -1f;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
    }


    private void Jump()
    {        
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        lastJumpTime = Time.time;
        hasJumped = true;
    }
    
    private void Move()
    {
        direction.y = rb.velocity.y;
        rb.velocity = direction;
    }
    
    private void CheckIfGrounded()
    {
        bool grounded = false;
        
        foreach (var detector in groundLayerDetectors) 
        {
            if (!detector.Detect()) continue;
            grounded = true;
            break;
        }
        
        if (grounded && lastJumpTime + ignoreGroundedFor < Time.time)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }  
    }
}