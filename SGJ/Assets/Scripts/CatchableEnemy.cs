using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableEnemy : MonoBehaviour
{
    SavedTransform transformOnStart;
    SavedTransform onCatchTransform;
    public Sprite EnemySprite { get; private set; }

    private void Start()
    {
        transformOnStart = new SavedTransform(transform);
        
    }

    public void Catch()
    {
        EnemySprite = GetComponentInChildren<SpriteRenderer>().sprite;
        onCatchTransform = new SavedTransform(transform);
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
        onCatchTransform.ApplyTo(transform);
        
    }
    public void FullReset()
    {
        gameObject.SetActive(true);
        transformOnStart.ApplyTo(transform);
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
