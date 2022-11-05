using UnityEngine;
using DG.Tweening;
public class PortalAnimator : MonoBehaviour
{
    [SerializeField] float animationDuration = 0.4f;
    [SerializeField] Vector3 OpenPortalScale;
    [SerializeField] Vector3 ClosedPortalScale;
    public void OpenPortal()
    {
        transform.DOScale(OpenPortalScale, animationDuration);
    }

    public void ClosePortal()
    {
        transform.DOScale(ClosedPortalScale, animationDuration);
    }
}
