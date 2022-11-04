using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float force;
    [HideInInspector] public Vector2 movementVector;
    Rigidbody2D rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Jump()
    {
        if (isGrounded) rb.velocity = new Vector2(rb.velocity.x, force);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
