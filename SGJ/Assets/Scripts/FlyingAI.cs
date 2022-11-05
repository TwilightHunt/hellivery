using System.Collections;
using UnityEngine;

public enum FlyingDirection
{
    Vertical,
    Horizontal,
}
public class FlyingAI : MonoBehaviour, ISpawnable
{
    [SerializeField] float seconds;
    [SerializeField] FlyingDirection flyDirection;
    [SerializeField] float speed = 5f;
    Vector2 direction;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Init();
        
    }
    public void Init()
    {
        switch (flyDirection)
        {
            case FlyingDirection.Vertical:
                direction = Vector2.up;
                break;
            case FlyingDirection.Horizontal:
                direction = transform.right;
                break;
            default:
                Debug.LogError($"WRONG DIRECTION ON {gameObject.name}'s FLYING AI");
                break;
        }
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed; 
        
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(seconds);
        if (flyDirection == FlyingDirection.Horizontal) Flip();
        else
        {
            direction = direction * -1;
        }

        StartCoroutine(ChangeDirection());
    }
    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        direction = transform.right;
    }
}

public interface ISpawnable
{
    public abstract void Init();
}