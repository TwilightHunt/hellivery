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
    public UnityEngine.Events.UnityEvent OnListUpdate;

    public CatchState CurrentState { get; private set; }

    public bool IsIndexSelected { get; private set; } = false;
    public int MonsterIndex { get; private set; } = 0;
    public bool CanPlaceMonster { get; private set; }   
    public List<CatchableEnemy> CatchedEnemies { get; private set; } = new List<CatchableEnemy>();
    public int EnemyCapacity { get => enemyCapacity; }
    [SerializeField] int enemyCapacity = 1;
    public float CatchRadius { get => catchRadius; }
    [SerializeField] float catchRadius =10f;

    [SerializeField] float portalRadius = 0.3f;

    public float NewRotation { get; private set; } = 0;

    Camera mainCamera;
    private void Start()
    {
        CurrentState = CatchState.Idle;
        mainCamera = Camera.main;
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
        if (index + 1 <= enemyCapacity && index < CatchedEnemies.Count())
        {
            MonsterIndex = index;
            IsIndexSelected = true;
        }

    }
    void Release()
    {
       if (!IsIndexSelected) 
        {
            OnReleaseFail?.Invoke("No index selected");
            return;
        }
        if (!CanPlaceMonster)
        {
            OnReleaseFail?.Invoke("Not enough space");
            return;
        }
       
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        CatchedEnemies[MonsterIndex].Release(mousePosition,Quaternion.identity);
        CatchedEnemies[MonsterIndex].GetComponent<ISpawnable>().Init();
        CatchedEnemies.RemoveAt(MonsterIndex);
        OnListUpdate?.Invoke();
        OnReleaseSuccess?.Invoke();
        ChangeState(CatchState.Idle);
    }
    public void ReturnMonster(int index)
    {
        CatchedEnemies[index].Reset();
        CatchedEnemies.RemoveAt(index);
        ChangeState(CatchState.Idle);
        OnListUpdate?.Invoke();

    }
    void TryToCatch()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Vector2.Distance(mousePosition, transform.position) > catchRadius) return;
        var colliders = Physics2D.OverlapCircleAll(mousePosition, portalRadius);


        var enemy = colliders.FirstOrDefault(x => x.GetComponent<CatchableEnemy>() != null);
        if (enemy == null)
        {
            OnCatchFail?.Invoke("No monsters");
            return;
        }
        else
        {
            CatchableEnemy cEnemy = enemy.GetComponent<CatchableEnemy>();
            if (CatchedEnemies.Count() < enemyCapacity)
            {
                cEnemy.Catch();
                CatchedEnemies.Add(cEnemy);
                OnCatchSuccess?.Invoke();
                OnListUpdate?.Invoke();
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
                ChangeState(CatchState.Catching);
                return;
            }
            if (Input.GetButtonDown("EButton"))
            {
                ChangeState(CatchState.Releasing);
                return;
            }
        }
        if(CurrentState == CatchState.Releasing)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                NewRotation += 180;
            }

            if (IsIndexSelected)
            {
                var mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                CanPlaceMonster = !Physics2D.BoxCast(mousePos, CatchedEnemies[MonsterIndex].EnemySprite.bounds.size, 0, Vector2.zero) && 
                    Vector2.Distance(mousePos, transform.position) <= catchRadius;
            }
            int desiredIndex = -1;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                desiredIndex = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                desiredIndex = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                desiredIndex = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                desiredIndex = 3;
            }
            if (desiredIndex == -1) return;
            SetMonsterIndex(desiredIndex);
        }

    }
    public void ChangeState(CatchState newState)
    {
        IsIndexSelected = false;
        MonsterIndex = -1;
        NewRotation = 0;
        CurrentState = newState;
        OnCatchStateChanged?.Invoke();
    }
}
