using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection;
    Animator animator;
    Rigidbody2D rb;
    bool isMovingForward;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        isMovingForward = true;
    }

    private void Update()
    {
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (isMovingForward && moveDirection.x < 0)
        {
            Flip();
            isMovingForward=false;
        }
        else if(!isMovingForward && moveDirection.x > 0)
        {
            Flip();
            isMovingForward = true;
        }
    }
    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
