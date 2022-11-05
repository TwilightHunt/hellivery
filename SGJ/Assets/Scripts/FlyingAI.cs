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
    float currentSeconds;
    int directionModifier = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Init();
        StartCoroutine(ChangeDirection());

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
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * directionModifier * speed; 

        
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(ChangeDirection());
    }
}
