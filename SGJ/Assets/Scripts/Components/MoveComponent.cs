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
        rb.velocity = movementVector * speed;
    }

    void FixedUpdate()
    {
    }
}
