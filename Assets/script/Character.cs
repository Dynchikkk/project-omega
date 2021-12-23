using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [Header("Main Characteristic")]

    //0 - Player, 1 - Enemy
    public int team = 0;
    public int currentHp = 0;
    public int maxHp = 40;
    public int damage;
    public int armor = 5;

    public List<GameObject> selfCards = new List<GameObject>();
    public List<GameObject> currentCards = new List<GameObject>();
    public List<GameObject> passedCards = new List<GameObject>();

    [Header("Other")]

    public GameObject target = null;

    private MainScr mainScript;

    // 0 - Armor, 1 - Attack
    private int nextStep = 1;

    private void Start()
    {
        currentHp = maxHp;
        print(name + nextStep.ToString());
        mainScript = Camera.main.GetComponent<MainScr>();
        for (int i = 0; i < 8; i++)
        {
            selfCards.Add(mainScript.allCards[Random.Range(0, mainScript.allCards.Count)]);
        }

        for (int i = 0; i < 4; i++)
        {
            currentCards.Add(selfCards[0]);
            selfCards.RemoveAt(0);
        }

        findTarget();
    }

    public void enemyAction()
    {
        if(nextStep == 1)
        {
            enAttack();
            print(name + nextStep.ToString());
        }
        if (nextStep == 0)
        {
            enGetArmor();
            print(name + nextStep.ToString());
        }
    }

    public void enAttack()
    {
        target.GetComponent<Character>().currentHp -= damage;
        nextStep = Random.Range(0, 2);
    }

    public void enGetArmor()
    {
        currentHp += armor;
        nextStep = Random.Range(0, 2);
    }

    public void findTarget()
    {
        Object[] allUnit = FindObjectsOfType<Character>();
        for (int i = 0; i < allUnit.Length; i++)
        {
            if (((Character)allUnit[i]).team != team)
            {
                target = ((Character)allUnit[i]).gameObject;
                break;
            }
        }
    }
}
