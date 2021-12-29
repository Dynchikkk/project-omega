using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScr : MonoBehaviour
{
    public int Stamina = 3;
    public TextMeshProUGUI staminaTxt;

    public GameObject plParent;
    public GameObject enParent;

    public GameObject player;
    private GameObject playerLink;

    public List<GameObject> enemyList = new List<GameObject>();

    public TextMeshProUGUI playerHpTxt;
    public TextMeshProUGUI EnemyHpAndNextStep;

    [Header("Work With Card")]

    public List<GameObject> allCards = new List<GameObject>();

    public List<TextMeshProUGUI> allCardText = new List<TextMeshProUGUI>();
    public TextMeshProUGUI passedCardsTxt;
    public TextMeshProUGUI inGameCardsTxt;

    private void Awake()
    {
        playerLink = Instantiate(player, plParent.transform);
        Instantiate(enemyList[Random.Range(0, enemyList.Count)], enParent.transform);
    }

    public void ReupdateCardsText()
    {
        for (int i = 0; i < allCardText.Count; i++)
        {
            if (playerLink.GetComponent<Character>().currentCards[i] != null)
            {
                allCardText[i].text = playerLink.GetComponent<Character>().currentCards[i].name;
            }
            else
            {
                allCardText[i].text = "null";
            }
        }

        staminaTxt.text = "Stamina: " + Stamina.ToString();

        passedCardsTxt.text = "Passed Cards: " + playerLink.GetComponent<Character>().passedCards.Count.ToString();
        inGameCardsTxt.text = "Cards In Hand: " + playerLink.GetComponent<Character>().selfCards.Count.ToString();
    }
}
