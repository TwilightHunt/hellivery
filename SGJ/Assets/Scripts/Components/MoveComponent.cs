using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float speed;
    InputComponent input;

    void Start()
    {
        input = GetComponent<InputComponent>();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = input.movementVector * speed * Time.deltaTime * 10f;
    }
}
