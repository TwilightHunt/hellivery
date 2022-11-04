using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public Vector2 movementVector;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        Debug.Log("Move");
        rb.velocity = movementVector * speed;
    }
    public void Jump()
    {
        Debug.Log("Jump");
    }
    void FixedUpdate()
    {
    }
}
