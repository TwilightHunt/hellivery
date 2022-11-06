using System.Collections;
using UnityEngine;

public class GroundMoveComponent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnJump;
    public UnityEngine.Events.UnityEvent OnLand;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [HideInInspector] public Vector2 MovementVector;
    Rigidbody2D rb;
    [SerializeField] bool canJump = true;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    const float k_GroundedRadius = .2f;
    [SerializeField] float knockedTime;
    public bool IsKnocked { get; private set; }
    public bool IsGrounded { get; private set; }

    Rigidbody2D movingPlatformRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Jump()
    {
        if (IsGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            OnJump?.Invoke();
            GetComponentInChildren<PlayerAnimationController>().SetAnimation("JumpAnimation");
        }
    }
    public void KnockAway(Vector2 impactPosition,float force)
    {
        IsKnocked = true;
        StartCoroutine(StartKnockTimer());
        rb.AddForce(impactPosition*-1 * force,ForceMode2D.Impulse);    
    }
    public void SetMovingPlatform(Rigidbody2D movingPlatformRb)
    {
        this.movingPlatformRb = movingPlatformRb;
    }
    void CheckGround()
    {
        if (canJump)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, groundMask);
            if (colliders.Length > 0)
            {
                if (!IsGrounded)
                {
                    OnLand?.Invoke();
                    IsGrounded = true;
                }
            }
            else IsGrounded = false;
        }
    }
    IEnumerator StartKnockTimer()
    {
        yield return new WaitForSeconds(knockedTime);
        IsKnocked = false;
    }
    void Update()
    {
        CheckGround();
        if (!IsKnocked)
        {
            if (movingPlatformRb == null)
            {
                rb.velocity = new Vector2(MovementVector.x * speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(MovementVector.x * speed + movingPlatformRb.velocity.x, rb.velocity.y);
            }
        }
    }
}
