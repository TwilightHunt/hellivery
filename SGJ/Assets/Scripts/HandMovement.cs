using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HandMovement : MonoBehaviour
{
    public Vector3 EndRotation;
    public float Duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(EndRotation,0.3f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
