using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [HideInInspector] public Vector2 MovementVector;
    Rigidbody2D rb;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    const float k_GroundedRadius = .2f;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Jump()
    {
        if (isGrounded)
        {
        rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius,groundMask);
        if(colliders.Length>0) isGrounded = true;
        else isGrounded = false;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(MovementVector.x * speed, rb.velocity.y);
    }
}
