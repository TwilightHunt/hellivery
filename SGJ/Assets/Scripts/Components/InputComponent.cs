using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputComponent : MonoBehaviour
{

    GroundMoveComponent moveComponent;
    EnemyCatcher catcherComponent;
    PlayerAnimationController playerAnimationController;
    private void Start()
    {
        playerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        moveComponent = GetComponent<GroundMoveComponent>();
        catcherComponent = GetComponent<EnemyCatcher>();
    }

    public void OnJump()
    {
        moveComponent.Jump();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        var moveDir = context.ReadValue<Vector2>();
        moveComponent.MovementVector = moveDir;
        playerAnimationController.moveDirection = moveDir;
    }

    public void On1stMouseButtonClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            catcherComponent.OnMouseButtonClick();
        }
    }

}
