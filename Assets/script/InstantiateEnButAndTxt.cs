using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstantiateEnButAndTxt : MonoBehaviour
{
    private MainScr mainScript;

    public GameObject parent;

    public TextMeshProUGUI TxtLink = null;
    public Button ButLink = null;

    public List<TextMeshProUGUI> allTxtLinks = new List<TextMeshProUGUI>();
    public List<Button> allButLinks = new List<Button>();

    public int Ox = 0;
    public int Oy = 140;

    private int numEn = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainScript = Camera.main.GetComponent<MainScr>();

        for (int i = 0; i < mainScript.enParent.transform.childCount; i++)
        {
            TextMeshProUGUI linkText = Instantiate(TxtLink, parent.transform);
            linkText.transform.localPosition = new Vector3(Ox, Oy, 0);
            allTxtLinks.Add(linkText);
            
            Oy *= -1;

            Button linkBut = Instantiate(ButLink, parent.transform);
            linkBut.transform.localPosition = new Vector3(Ox, Oy, 0);
            linkBut.GetComponent<ChrBut>().numEn = numEn;
            allButLinks.Add(linkBut);

            Oy *= -1;
            Ox -= 130;
        }
    }
}
