using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrawer : MonoBehaviour
{
    EnemyCatcher enemyCatcher;
    CatchableEnemy selectedEnemy;
    SpriteRenderer spriteRenderer;

    [SerializeField] Color canPlaceColor;
    [SerializeField] Color canNtPlaceColor;

    private void Start()
    {
        
        enemyCatcher = FindObjectOfType<EnemyCatcher>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (enemyCatcher.CurrentState == CatchState.Releasing && enemyCatcher.IsIndexSelected)
        {
            if(enemyCatcher.CatchedEnemies[enemyCatcher.MonsterIndex] != selectedEnemy)
            {
                selectedEnemy = enemyCatcher.CatchedEnemies[enemyCatcher.MonsterIndex];
            }
            spriteRenderer.sprite = selectedEnemy.EnemySprite;
            spriteRenderer.color = enemyCatcher.CanPlaceMonster ? canPlaceColor : canNtPlaceColor;

        }
        else if (spriteRenderer.sprite != null) spriteRenderer.sprite = null;
    }
}
