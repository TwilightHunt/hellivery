using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLogic : MonoBehaviour
{
    [SerializeField] float respawnTime = 15f;
    public void Respawn()
    {
        GetComponent<CatchableEnemy>().FullReset();
    }
    public void OnDeath()
    {
        StartCoroutine(WaitForRespawn());
        gameObject.SetActive(false);
    }
    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }

}
