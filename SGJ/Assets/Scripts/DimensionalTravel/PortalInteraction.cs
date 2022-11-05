
using UnityEngine;
using UnityEngine.Events;

public class PortalInteraction : MonoBehaviour
{
    bool canInteract = false;
    public UnityEvent OnPortalTeleportation;
    public UnityEvent OnPortalTriggerEnter;
    public UnityEvent OnPortalTriggerExit;

    [SerializeField] PortalInteraction OtherPortal;

    GameObject PlayerObject;
    private void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        OnPortalTriggerEnter?.Invoke();
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        OnPortalTriggerExit?.Invoke();
        canInteract = false;
    }
    void Teleport()
    {
        PlayerObject.transform.position = OtherPortal.transform.position;
        OnPortalTeleportation?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetButtonDown("Interact"))
        {
            Teleport();
        }
    }
}
