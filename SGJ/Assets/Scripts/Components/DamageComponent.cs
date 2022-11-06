using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] int heartsDamage = 1;
    [SerializeField] float knockPower = 3f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.contacts[0].otherCollider.gameObject.GetComponent<DamageComponent>()) return;
        var healthComp = collision.gameObject.GetComponent<HealthComponent>();
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<GroundMoveComponent>().KnockAway(collision.GetContact(0).normal, knockPower);
        }
        if (healthComp)
        {
            healthComp.GetDamage(heartsDamage);
        }
    }
}
