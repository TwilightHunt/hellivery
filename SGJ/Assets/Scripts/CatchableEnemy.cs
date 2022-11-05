using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableEnemy : MonoBehaviour
{
    SavedTransform transformOnCatch;

    public Sprite EnemySprite { get; private set; }
    
    private void Start()
    {
        EnemySprite = GetComponentInChildren<SpriteRenderer>().sprite;
    }
    public void Catch()
    {
        gameObject.SetActive(false);
    }
    public void Release(Vector2 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = rotation;
    }
    public void Reset()
    {
        gameObject.SetActive(true);
    }
}

public class SavedTransform
{
    public Vector3 LocalPosition;
    public Vector3 LocalEulerRotation;
    public Vector3 LocalScale;
    public SavedTransform()
    {

    }
    public SavedTransform(Transform transformToCopy)
    {
        LocalPosition = transformToCopy.localPosition;
        LocalEulerRotation = transformToCopy.localEulerAngles;
        LocalScale = transformToCopy.localScale;
    }

    public void ApplyTo(Transform transform)
    {
        transform.localPosition = LocalPosition;
        transform.localEulerAngles = LocalEulerRotation;
        transform.localScale = LocalScale;
    }
}
