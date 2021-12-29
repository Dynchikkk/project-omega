using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChrBut : MonoBehaviour
{
    private Character pl;
    private MainScr mainScript;

    public GameObject privateEnemy = null;

    [SerializeField] private int numEn = 0;

    private void Start()
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

        privateEnemy = mainScript.enParent.transform.GetChild(numEn).gameObject;

        gameObject.GetComponent<Button>().enabled = false;
    }

    public void OnChooseThisTrg()
    {
        pl.target = privateEnemy;
        print(pl.target.name);

        CardClick clickScr = FindObjectOfType<CardClick>();

        Instantiate(pl.currentCards[clickScr.numCard], pl.gameObject.transform);
        pl.passedCards.Add(pl.currentCards[clickScr.numCard]);
        pl.currentCards[clickScr.numCard] = null;

        clickScr.chooseCard = false;
        clickScr.numCard = -1;

        pl.target.GetComponent<Character>().CharscteristicTxt();

        mainScript.ReupdateCardsText();
        gameObject.GetComponent<Button>().enabled = false;

        for (int i = 0; i < clickScr.gameObject.transform.childCount; i++)
        {
            clickScr.gameObject.transform.GetChild(i).GetComponent<Graphic>().color = Color.white;
        }
    }
}
