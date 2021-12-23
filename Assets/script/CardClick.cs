using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClick : MonoBehaviour
{
    private Character pl;

    public void OnClick(int num)
    {
        Object[] allUnit = FindObjectsOfType<Character>();
        for (int i = 0; i < allUnit.Length; i++)
        {
            if (((Character)allUnit[i]).team == 0)
            {
                pl = (Character)allUnit[i];
                break;
            }
        }
        print(pl.currentCards.Count);
        print(num);

        Instantiate(pl.currentCards[num], pl.gameObject.transform);
        pl.passedCards.Add(pl.currentCards[num]);
        pl.currentCards[num] = null;
    }
}
