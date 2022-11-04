using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAI : MonoBehaviour
{
    [SerializeField] float seconds;
    Vector2 direction = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime); 
    }

    IEnumerator ChangeDirection()
    {
        direction *= -1;

        yield return new WaitForSeconds(seconds);
        StartCoroutine(ChangeDirection());
    }
}
