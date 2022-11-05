using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUIController : MonoBehaviour
{
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
