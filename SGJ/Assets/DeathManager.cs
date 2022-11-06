using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public GameObject lastCheckPoint;
    
    public void Death()
    {
        Debug.Log("death");
        transform.position = lastCheckPoint.transform.position;
    }
}
