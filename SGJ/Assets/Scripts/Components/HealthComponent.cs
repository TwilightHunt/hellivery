using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnDeath;
    public UnityEngine.Events.UnityEvent OnHeal;

    public int MaxHealth = 4;
    public int CurrentHealth;
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void GetDamage(int damage)
    {
        CurrentHealth-=damage;
        if(CurrentHealth<=0) OnDeath.Invoke();
    }
    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("Death");

        OnDeath.Invoke();
    }
}
