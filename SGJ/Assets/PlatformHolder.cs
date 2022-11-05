using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHolder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y > transform.position.y) 
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
