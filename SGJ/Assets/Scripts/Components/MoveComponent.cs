using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public Vector2 movementVector;

    void Start()
    {
       
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movementVector * speed * Time.deltaTime * 10f;
    }
}
