using UnityEngine;

public class PlatformHolder : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void OnDisable()
    {
        Debug.Log("Disabled");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.position.y > transform.position.y) 
        {
            var moveComp = collision.gameObject.GetComponent<GroundMoveComponent>();
            if (moveComp != null)
            {
                moveComp.SetMovingPlatform(rb);
                moveComp.transform.parent = transform;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        var moveComp = collision.gameObject.GetComponent<GroundMoveComponent>();
        if (moveComp != null)
        {
            moveComp.SetMovingPlatform(null);
            moveComp.transform.parent = null;
        }
    }
}
