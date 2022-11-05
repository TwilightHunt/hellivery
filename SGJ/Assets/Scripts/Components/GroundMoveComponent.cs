using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveComponent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnJump;
    public UnityEngine.Events.UnityEvent OnLand;

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
            OnJump?.Invoke();
        }
    }
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius,groundMask);
        if (colliders.Length > 0) 
        {
            if (!isGrounded)
            {
                isGrounded = true;
                OnLand?.Invoke();
            }
        }
        else isGrounded = false;
    }
    void FixedUpdate()
    {

        rb.velocity = new Vector2(MovementVector.x * speed, rb.velocity.y);
    }
}
