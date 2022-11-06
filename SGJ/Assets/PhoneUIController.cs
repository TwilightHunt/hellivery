using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUIController : MonoBehaviour
{
    [SerializeField] UIMenu MainMenu;
    [SerializeField] UIMenu SummonMenu;
    [SerializeField] UIMenu CatchMenu;
    [SerializeField] UIMenu HiddenMenu;
    UIMenu enabledMenu;
    bool isHidden;
    EnemyCatcher catcherController;
    void Start()
    {
        isHidden = false;
        catcherController = FindObjectOfType<EnemyCatcher>();
        catcherController.OnCatchStateChanged.AddListener(OnStateChange);
        EnableMenu(MainMenu);
    }
    void EnableMenu(UIMenu newMenu)
    {
        if(enabledMenu != null) enabledMenu.Close();
        newMenu.Enable();
        enabledMenu = newMenu;
    }
    void OnStateChange()
    {
        if (isHidden) return;
        switch (catcherController.CurrentState)
        {
            case CatchState.Idle:
                EnableMenu(MainMenu);
                break;
            case CatchState.Catching:
                EnableMenu(CatchMenu);
                break;
            case CatchState.Releasing:
                EnableMenu(SummonMenu);
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
    public abstract void Close();
}
