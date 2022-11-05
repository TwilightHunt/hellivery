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
    public UnityEngine.Events.UnityEvent<string> OnReleaseFail;
    public UnityEngine.Events.UnityEvent OnReleaseSuccess;
    public UnityEngine.Events.UnityEvent OnCatchStateChanged;


    public CatchState CurrentState { get; private set; }

    bool isIndexSelected = false;
    int indexToRelease = 0;

    List<CatchableEnemy> catchedEnemies = new List<CatchableEnemy>();
    public int EnemyCapacity { get => enemyCapacity; }
    [SerializeField] int enemyCapacity = 1;
    public float CatchRadius { get => catchRadius; }
    [SerializeField] float catchRadius =10f;

    [SerializeField] float portalRadius = 0.3f;

    private void Start()
    {
        CurrentState = CatchState.Idle;
    }
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
                Release();
                break;
            default:
                break;
        }
    }
    public void SetMonsterIndex(int index)
    {
        indexToRelease = index;
        isIndexSelected = true;
    }
    void Release()
    {
       // if (!isIndexSelected) return;
        
       
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        catchedEnemies[0].Release(mousePosition,Quaternion.identity);
        catchedEnemies[0].GetComponent<ISpawnable>().Init();
        catchedEnemies.RemoveAt(0);
        CurrentState = CatchState.Idle;
    }
    void TryToCatch()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Vector2.Distance(mousePosition, transform.position) > catchRadius) return;
        var colliders = Physics2D.OverlapCircleAll(mousePosition, portalRadius);


        var enemy = colliders.FirstOrDefault(x => x.GetComponent<CatchableEnemy>() != null);
        if (enemy == null)
        {
            OnCatchFail?.Invoke("No monsters found");
            return;
        }
        else
        {
            CatchableEnemy cEnemy = enemy.GetComponent<CatchableEnemy>();
            if (catchedEnemies.Count() < enemyCapacity)
            {
                cEnemy.Catch();
                catchedEnemies.Add(cEnemy);
                OnCatchSuccess?.Invoke();
            }
            else
            {
                OnCatchFail?.Invoke("No more room for monsters");
            }
        }
        ChangeState(CatchState.Idle);
    }
    private void Update()
    {
        if(CurrentState == CatchState.Idle)
        {
            if (Input.GetButtonDown("QButton"))
            {
                CurrentState = CatchState.Catching;
                return;
            }
            if (Input.GetButtonDown("EButton"))
            {
                CurrentState = CatchState.Releasing;
                return;
            }
        }

    }
    public void ChangeState(CatchState newState)
    {
        isIndexSelected = false;
        indexToRelease = -1;
        CurrentState = newState;
        OnCatchStateChanged?.Invoke();
    }
}
