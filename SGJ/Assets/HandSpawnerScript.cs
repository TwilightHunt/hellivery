using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpawnerScript : MonoBehaviour
{
    public List<Sprite> handSprites;
    public HandMovement handPrefab;
    public float timeBetweenSpawns;
    void Start()
    {
        StartCoroutine(SpawnHand());
    }
    IEnumerator SpawnHand()
    {
        var hand = Instantiate(handPrefab, transform.position, Quaternion.identity);
        hand.Init();
        hand.GetComponent<SpriteRenderer>().sprite = handSprites[Random.Range(0, handSprites.Count-1)];
        yield return new WaitForSeconds(timeBetweenSpawns);
        timeBetweenSpawns = Random.Range(0.4f, 4f);
        StartCoroutine(SpawnHand());
    }

}
