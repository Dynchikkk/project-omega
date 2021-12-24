using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClick : MonoBehaviour
{
    private Character pl;
    private MainScr mainScript;

    public void OnClick(int num)
    {
        mainScript = Camera.main.GetComponent<MainScr>();
        Object[] allUnit = FindObjectsOfType<Character>();
        for (int i = 0; i < allUnit.Length; i++)
        {
            if (((Character)allUnit[i]).team == 0)
            {
                pl = (Character)allUnit[i];
                break;
            }
        }

        Instantiate(pl.currentCards[num], pl.gameObject.transform);
        pl.passedCards.Add(pl.currentCards[num]);
        pl.currentCards[num] = null;

        pl.target.GetComponent<Character>().CharscteristicTxt();

        mainScript.ReupdateCardsText();
    }
}
