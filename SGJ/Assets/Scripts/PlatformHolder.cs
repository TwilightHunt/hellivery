using UnityEngine;

public class PlatformHolder : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.position.y > transform.position.y) 
        {
            Debug.Log("Catched");
            var moveComp = collision.gameObject.GetComponent<GroundMoveComponent>();
            if (moveComp != null)
            {
                moveComp.SetMovingPlatform(rb);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        var moveComp = collision.gameObject.GetComponent<GroundMoveComponent>();
        if (moveComp != null)
        {
            moveComp.SetMovingPlatform(null);
        }
    }
}
