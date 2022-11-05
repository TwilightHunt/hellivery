using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlyingDirection
{
    Vertical,
    Horizontal,
}
public class FlyingAI : MonoBehaviour
{
    [SerializeField] float seconds;
    [SerializeField] FlyingDirection flyDirection;
    [SerializeField] float speed = 5f;
    Vector2 direction;
    int directionModifier = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switch (flyDirection)
        {
            case FlyingDirection.Vertical:
                direction = new Vector2(0, 1);
                break;
            case FlyingDirection.Horizontal:
                direction = new Vector2(1, 0);
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
        rb.velocity = direction * directionModifier * speed; 

    }

    IEnumerator ChangeDirection()
    {
        directionModifier *= -1;

        yield return new WaitForSeconds(seconds);
        StartCoroutine(ChangeDirection());
    }
}
