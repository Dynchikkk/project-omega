using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallArmorCard : MonoBehaviour
{
    public int armor = 5;
    public int stm = 1;

    private Character pl;
    void Start()
    {
        findPlayer();

        if (Camera.main.GetComponent<MainScr>().Stamina - stm >= 0)
        {
            Camera.main.GetComponent<MainScr>().Stamina -= stm;

            pl.currentHp += armor;

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
