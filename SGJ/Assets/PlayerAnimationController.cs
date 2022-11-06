using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection;
    Animator animator;
    Rigidbody2D rb;
    GroundMoveComponent moveComponent;
    bool isMovingForward;
    public float FallingThreshold = -10f;
    public bool isFalling;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        isMovingForward = true;
        moveComponent = GetComponentInParent<GroundMoveComponent>();
        moveComponent.OnJump.AddListener(OnJump);
        moveComponent.OnLand.AddListener(OnLand);
    }
    void OnJump()
    {
        animator.SetTrigger("OnJump");
    }
    void OnLand()
    {
        animator.SetTrigger("OnLand");
    }
    private void Update()
    {
        animator.SetInteger("HorizontalSpeed", (int)Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
        if (isMovingForward && moveDirection.x < 0)
        {
            Flip();
            isMovingForward = false;
        }
        else if(!isMovingForward && moveDirection.x > 0)
        {
            Flip();
            isMovingForward = true;
        }

        //if (isFalling && !animator.GetCurrentAnimatorStateInfo(0).IsName("FlyAnimation")) { SetAnimation("FlyDown"); }
    }
    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

}
