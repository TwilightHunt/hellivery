using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonUIController : UIMenu
{
    [SerializeField] MonsterCardUI cardPrefab;
    List<CatchableEnemy> enemiesList;
    List<MonsterCardUI> cardsList = new List<MonsterCardUI> ();
    EnemyCatcher enemyCatcher;
    public override void Close()
    {
        gameObject.SetActive (false);
    }

    public override void Enable()
    {
        if(enemyCatcher == null)
        {
            enemyCatcher = FindObjectOfType<EnemyCatcher>();
            enemyCatcher.OnListUpdate.AddListener(LoadCards);
        }
        if(enemyCatcher.CatchedEnemies != enemiesList)
        {
            LoadCards();
        }
        gameObject.SetActive(true);

    }
    void LoadCards()
    {
        if (cardsList.Count > 0)
        {
            foreach (var card in cardsList)
            {
                Destroy(card.gameObject);
            }
            cardsList.Clear();
        }
        enemiesList = enemyCatcher.CatchedEnemies;
        for (int i = 0; i < enemiesList.Count; i++)
        {
            var newCard = Instantiate(cardPrefab, transform);
            newCard.Init(i,enemiesList[i]);
            cardsList.Add(newCard);
        }
    }

}
