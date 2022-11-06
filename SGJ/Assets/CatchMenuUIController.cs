using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMenuUIController : UIMenu
{
    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Enable()
    {
        gameObject.SetActive(true);
    }

}
