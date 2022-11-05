using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum CatchState
{
    Idle,
    Catching,
    Releasing
}
public class EnemyCatcher : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent<string> OnCatchFail;
    public UnityEngine.Events.UnityEvent OnCatchSuccess;

    public CatchState CurrentState;

    List<CatchableEnemy> catchedEnemies = new List<CatchableEnemy>();
    public int EnemyCapacity { get => enemyCapacity; }
    [SerializeField] int enemyCapacity = 1;
    public float CatchRadius { get => catchRadius; }
    [SerializeField] float catchRadius =10f;

    [SerializeField] float portalRadius = 0.3f;

    public void IncreaseRadius(float additionalRadius)
    {
        catchRadius += additionalRadius;
    }
    public void IncreaseEnemyCapacity()
    {
        enemyCapacity++;
    }
    public void OnMouseButtonClick()
    {
        switch (CurrentState)
        {
            case CatchState.Idle:
                break;
            case CatchState.Catching:
                TryToCatch();
                break;
            case CatchState.Releasing:
                break;
            default:
                break;
        }
    }
    public void TryToCatch()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Vector2.Distance(mousePosition, transform.position) > catchRadius) return;
        var colliders = Physics2D.OverlapCircleAll(mousePosition, portalRadius);


        var enemy = colliders.FirstOrDefault(x => x.GetComponent<CatchableEnemy>() != null);
        if (enemy == null) return;
        else
        {
            CatchableEnemy cEnemy = enemy.GetComponent<CatchableEnemy>();
            if (catchedEnemies.Count() < enemyCapacity)
            {
                cEnemy.Catch();
                catchedEnemies.Add(cEnemy);
            }
        }
    }
    private void Update()
    {

    }
}
