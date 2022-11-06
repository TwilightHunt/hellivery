using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource walkSource;

    Rigidbody2D rb;
    GroundMoveComponent groundMove;
    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        groundMove = GetComponentInParent<GroundMoveComponent>();
    }
    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!= 0 && groundMove.IsGrounded) walkSource.Play();
        else if(Input.GetAxisRaw("Horizontal") == 0 || !groundMove.IsGrounded) walkSource.Stop();
    }
}
