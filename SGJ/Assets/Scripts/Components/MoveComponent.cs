using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public Vector2 movementVector;
    Rigidbody2D rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Jump()
    {
        Debug.Log("Jump!");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
    }
}
