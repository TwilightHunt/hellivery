using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuAction : MonoBehaviour
{
    [SerializeField] Button defaultButton;
    public void OnMove(InputAction.CallbackContext context)
    {
        if (EventSystem.current.currentSelectedGameObject == null) { defaultButton.Select(); }
    }
}
