using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FuguLogic : MonoBehaviour, ISpawnable
{
    [Header("Explosion properties")]
    [SerializeField] float explosionRadius = 3f;
    [SerializeField] int damage = 1;
    [SerializeField] float explosionForce = 1.5f;
    [SerializeField] GameObject explosionParticles;
    [Header("Explosion distance")]
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;
    [SerializeField] List<Sprite> fuguSprites;

    [Header("Explosion after spawn")]
    [SerializeField] float explosionTimer = 1.5f;
    

    public bool IsBomb { get; private set; }


    GameObject playerObject;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        GetComponentInChildren<Animator>().enabled = false;
    }
    private void Update()
    {
        if (!IsBomb)
        {
            var distance = Vector2.Distance(transform.position, playerObject.transform.position);
            if (distance < maxDistance)
            {
                if (distance > minDistance)
                {
                    float segment = (maxDistance - minDistance) / fuguSprites.Count;

                    int explosionState = (int)(fuguSprites.Count + 2 - (distance / segment));
                    explosionState = Mathf.Clamp(explosionState, 0, fuguSprites.Count - 1);
                    spriteRenderer.sprite = fuguSprites[explosionState];
                }
                else
                {
                    Explode();
                }
            }
        }
    }
    private void Explode()
    {
        var gotHit = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (var item in gotHit)
        {

            var healthComp = item.GetComponent<HealthComponent>();
            if (healthComp)
            {
                healthComp.GetDamage(damage);
            }
            if (item.CompareTag("Player"))
            {

                item.GetComponent<GroundMoveComponent>().KnockAway(transform.position - item.transform.position, explosionForce);
            }
        }
        //var explosion = Instantiate(explosionParticles);
        //Destroy(explosion, 3f);
        GetComponent<RespawnLogic>().OnDeath();
    }

    public void Init()
    {
        IsBomb = true;
        GetComponentInChildren<Animator>().enabled = true;
        GetComponentInChildren<Animator>().SetBool("IsBomb", true);
        StartCoroutine(ExplosionTimer());
    }
    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(explosionTimer);
        Explode();
    }
}
