using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    MoveComponent moveComponent;

    private void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
    }

    public void OnJump()
    {
        moveComponent.Jump();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveComponent.MovementVector = context.ReadValue<Vector2>();
    }


}
