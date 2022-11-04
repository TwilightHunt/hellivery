using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    public Vector2 movementVector { get; private set; }
    MoveComponent moveComponent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveComponent.movementVector = context.ReadValue<Vector2>();
    }
}
