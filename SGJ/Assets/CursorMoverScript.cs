using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMoverScript : MonoBehaviour
{
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        position.z = 0;
        transform.position = position;
    }
}
