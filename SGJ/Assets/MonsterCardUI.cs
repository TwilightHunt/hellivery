using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterCardUI : MonoBehaviour
{
    int storedIndex;
    [SerializeField] TMP_Text monsterIndexText;
    [SerializeField] Image monsterImage;
    public void Init(int index, CatchableEnemy storedEnemy)
    {
        storedIndex = index; 
        var imageRenderer = GetComponent<Image>();
        monsterImage.sprite = storedEnemy.EnemySprite;
        monsterIndexText.text = (storedIndex+1).ToString();
    }
    public void ResetMonsterButton()
    {
        FindObjectOfType<EnemyCatcher>().ReturnMonster(storedIndex);
    }
    public void SetIndexButton()
    {
        FindObjectOfType<EnemyCatcher>().SetMonsterIndex(storedIndex);
    }
}
