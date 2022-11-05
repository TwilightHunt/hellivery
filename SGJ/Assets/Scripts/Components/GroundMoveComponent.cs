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
    bool isGrounded;

    Rigidbody2D movingPlatformRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Jump()
    {
        if (isGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            OnJump?.Invoke();
            GetComponentInChildren<PlayerAnimationController>().SetAnimation("JumpAnimation");
        }
    }
    private void Update()
    {
        if (canJump)
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

        GetComponentInChildren<PlayerAnimationController>().isFalling = !isGrounded;
    }

    public void SetMovingPlatform(Rigidbody2D movingPlatformRb)
    {
        this.movingPlatformRb = movingPlatformRb;
    }
    void FixedUpdate()
    {
        if(movingPlatformRb == null)
        {
            rb.velocity = new Vector2(MovementVector.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(MovementVector.x * speed + movingPlatformRb.velocity.x, rb.velocity.y);
        }
    }
}
