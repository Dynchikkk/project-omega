using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAttackCard : MonoBehaviour
{
    public int damage = 5;
    public int stm = 1;

    private Character pl;
    private GameObject target;

    void Start()
    {
        findPlayer();

        if (Camera.main.GetComponent<MainScr>().Stamina - stm >= 0)
        {
            Camera.main.GetComponent<MainScr>().Stamina -= stm;

            pl.target.GetComponent<Character>().currentHp -= damage;

            AfterUse();
        }
    }

    public void AfterUse()
    {
        Destroy(gameObject);
    }

    public void findPlayer()
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
    }
}
