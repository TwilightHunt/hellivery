using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAI : MonoBehaviour, ISpawnable
{
    [SerializeField] Vector2 moveDirection = new Vector2(1, 0);
    [SerializeField] float visionDistance;
    [SerializeField] float groundDistance;
    [SerializeField] Transform groundRaycastTransform;
    [SerializeField] Transform visionRaycastTransform;
    GroundMoveComponent moveComponent;

    void Start()
    {
        moveComponent = GetComponent<GroundMoveComponent>();
        Init();
    }

    void Update()
    {

        if (Physics2D.Raycast(visionRaycastTransform.position, moveDirection, visionDistance, ~LayerMask.GetMask("Ignore Raycast")))
        {
            Flip();
            SetMoveVector();
        }
        else if (!Physics2D.Raycast(groundRaycastTransform.position, Vector2.down, groundDistance, ~LayerMask.GetMask("Ignore Raycast")))
        {
            Flip();
            SetMoveVector();
        }
    }

    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        moveDirection = transform.right;
    }

    void SetMoveVector()
    {
        moveComponent.MovementVector = moveDirection;
    }

    public void Init()
    {
        moveDirection = transform.right;
        SetMoveVector();
    }
}
