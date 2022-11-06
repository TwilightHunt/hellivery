using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnDeath;
    public UnityEngine.Events.UnityEvent OnHeal;
    public UnityEngine.Events.UnityEvent OnTakeDamage;

    public int MaxHealth = 4;
    public int CurrentHealth;
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    public void Respawn()
    {
        CurrentHealth = MaxHealth;
    }
    public void GetDamage(int damage)
    {
        CurrentHealth-=damage;
        OnTakeDamage?.Invoke();
        if(CurrentHealth<=0) OnDeath.Invoke();

    }
}
