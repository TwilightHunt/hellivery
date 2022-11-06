using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        FindObjectOfType<EnemyCatcher>().ChangeState(CatchState.Idle);
    }
}
