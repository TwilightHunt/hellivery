using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HandMovement : MonoBehaviour
{
    public Vector3 EndRotation;
    public float MaxDuration;
    public float MinDuration = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        float Duration = Random.Range(MinDuration, MaxDuration);
        transform.DORotate(EndRotation, Duration).SetLoops(-1, LoopType.Yoyo);
    }

}
