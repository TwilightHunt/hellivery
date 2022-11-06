using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPanelScript : MonoBehaviour
{
    HealthComponent playerHealthComponent;
    [SerializeField] GameObject HeartPrefab;
    List<GameObject> heartsList = new List<GameObject> ();
    void Start()
    {
        playerHealthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>();
        playerHealthComponent.OnTakeDamage.AddListener(ReloadHearts);
        playerHealthComponent.OnHeal.AddListener(ReloadHearts);
        ReloadHearts ();
    }

    void ReloadHearts()
    {
        foreach (var heart in heartsList)
        {
            Destroy(heart.gameObject);
        }
        heartsList.Clear();
        for (int i = 0; i < playerHealthComponent.CurrentHealth; i++)
        {
            var heart = Instantiate(HeartPrefab, transform);
            heartsList.Add(heart);
        }

    }

}
