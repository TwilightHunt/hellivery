using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUIController : MonoBehaviour
{
    [SerializeField] UIMenu MainMenu;
    [SerializeField] UIMenu SummonMenu;
    [SerializeField] UIMenu CatchMenu;
    [SerializeField] UIMenu HiddenMenu;

    bool isHidden;
    EnemyCatcher catcherController;
    void Start()
    {
        isHidden = false;
        catcherController = FindObjectOfType<EnemyCatcher>();
        catcherController.OnCatchStateChanged.AddListener(OnStateChange);
    }

    void OnStateChange()
    {
        if (isHidden) return;
        switch (catcherController.CurrentState)
        {
            case CatchState.Idle:
                break;
            case CatchState.Catching:
                break;
            case CatchState.Releasing:
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
public abstract class UIMenu : MonoBehaviour
{
    public abstract void Enable();
}
