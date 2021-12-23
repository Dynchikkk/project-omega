using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    public int Stamina = 3;

    public GameObject plParent;
    public GameObject enParent;

    public GameObject player;

    public List<GameObject> enemyList = new List<GameObject>();

    public List<GameObject> allCards = new List<GameObject>();

    private void Start()
    {
        Instantiate(player, plParent.transform);
        Instantiate(enemyList[Random.Range(0, enemyList.Count)], enParent.transform);
    }
}
