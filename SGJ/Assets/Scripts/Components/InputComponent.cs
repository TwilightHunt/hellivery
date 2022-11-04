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
        moveComponent = GetComponent<MoveComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveComponent.Move(context.ReadValue<Vector2>());
    }
}
