using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HandMovement : MonoBehaviour
{
    public Vector3 EndRotation;
    public float MaxDuration;
    public float MinDuration = 0.1f;
    public float LifeTime = 5f;
    public float speed = 8f;
    // Start is called before the first frame update
    public void Init()
    {
        float Duration = Random.Range(MinDuration, MaxDuration);

        transform.DORotate(EndRotation, Duration).SetLoops(-1, LoopType.Yoyo);
        Destroy(gameObject,LifeTime);
    }
    private void Update()
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;

    }

}
