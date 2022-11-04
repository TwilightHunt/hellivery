using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    MoveComponent moveComponent;

    private void Start()
    {
        moveComponent = FindObjectOfType<MoveComponent>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        moveComponent.Jump();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveComponent.movementVector = context.ReadValue<Vector2>();
    }


}
