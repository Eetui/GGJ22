using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Test : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public float speed = 5.0f;
    public float jump_force = 5.0f;
    public float gravity = 10f;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Player.GetComponent<Rigidbody2D>().AddForce(moveDirection * speed);
        
    }
}
