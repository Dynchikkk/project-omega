using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClick : MonoBehaviour
{
    private Character pl;
    private MainScr mainScript;

    public bool chooseCard = false;
    public int numCard = -1;

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
    }

    public void OnClick(int num)
    {
        Object[] allEnCard = FindObjectsOfType<ChrBut>();
        print(allEnCard.Length);

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<Graphic>().color = Color.white;
        }
       
        if(chooseCard == false)
        {
            gameObject.transform.GetChild(num).GetComponent<Graphic>().color = Color.green;

            chooseCard = true;
            numCard = num;

            for (int i = 0; i < allEnCard.Length; i++)
            {
                ((ChrBut)allEnCard[i]).gameObject.GetComponent<Button>().enabled = true;
            }
        }
        else if(chooseCard == true)
        {
            gameObject.transform.GetChild(num).GetComponent<Graphic>().color = Color.white;

            chooseCard = false;
            numCard = -1;

            for (int i = 0; i < allEnCard.Length; i++)
            {
                ((ChrBut)allEnCard[i]).gameObject.GetComponent<Button>().enabled = false;
            }
        }

        print(numCard);
    }
}
