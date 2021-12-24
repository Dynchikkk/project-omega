using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStep : MonoBehaviour
{
    private Character pl;
    private MainScr mainScript;

    public void EndTheStep()
    {
        Object[] allEnemy = FindObjectsOfType<Character>();
        for (int i = 0; i < allEnemy.Length; i++)
        {
            if (((Character)allEnemy[i]).team == 0)
            {
                pl = (Character)allEnemy[i];
                break;
            }
        }

        mainScript = Camera.main.GetComponent<MainScr>();     

        if (mainScript.Stamina < 3)
        {
            mainScript.Stamina += 1;
        }

        for (int i = 0; i < pl.currentCards.Count; i++)
        {
            if(pl.currentCards[i] != null)
            {
                pl.passedCards.Add(pl.currentCards[i]);
            }
        }

        pl.currentCards.Clear();

        if (pl.selfCards.Count < 4)
        {
            pl.selfCards.AddRange(pl.passedCards);
            pl.passedCards.Clear();
        }

        for (int i = 0; i < 4; i++)
        {
            pl.currentCards.Add(pl.selfCards[0]);
            pl.selfCards.RemoveAt(0);
        }

        Object[] enTeam = FindObjectsOfType<Character>();
        for (int i = 0; i < enTeam.Length; i++)
        {
            if (((Character)enTeam[i]).team == 1)
            {
                ((Character)enTeam[i]).EnemyAction();
            }
        }

        mainScript.ReupdateCardsText();
        pl.target.GetComponent<Character>().CharscteristicTxt();
    }

    public void FindPlayer()
    {
        Object[] allUnit = FindObjectsOfType<Character>();
        for (int i = 0; i < allUnit.Length; i++)
        {
            if (((Character)allUnit[i]).team == 1)
            {
                pl = (Character)allUnit[i];
                break;
            }
        }
    }
}
