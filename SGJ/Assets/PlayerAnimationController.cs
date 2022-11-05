using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Vector2 moveDirection;
    Animator animator;
    Rigidbody2D rb;
    bool isMovingForward;
    public float FallingThreshold = -10f;
    public bool isFalling;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        isMovingForward = true;
    }

    private void Update()
    {
        animator.SetInteger("MovementSpeed", (int)Mathf.Abs(Input.GetAxisRaw("Horizontal")));
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

        animator.SetBool("isFalling", isFalling);
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
