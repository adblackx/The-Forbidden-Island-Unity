using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonController : MonoBehaviour
{
    private Island modele;
    private GameObject[] panelTab;
    // Start is called before the first frame update
    void Start()
    {
       /* GameObject hand = GameObject.Find("ButPlayer1");
        hand.transform.GetChild(0).GetComponent<Text>().text = modele.GetListPlayers()[0].toString();
        print("trouve "+hand.name);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setModele(Island modele)
    {
        this.modele = modele;
    }
    
    public void onButtonClickP0()
    {
        print("click p0");
        hideExcept(0);

    }
    public void onButtonClickP1()
    {
        print("click p1");
        hideExcept(1);

    }
    public void onButtonClickP2()
    {
        print("click p2");
        hideExcept(2);

    }
    public void onButtonClickP3()
    {
        print("click p3");
        hideExcept(3);

    }
    
    public void setPanelController(GameObject[] panelTab)
    {
        this.panelTab = panelTab;
    }

    public void hideExcept(int indice)
    {
        for (int i = 0; i < panelTab.Length; i++)
        {

            if (i == indice)
            {
                panelTab[i].SetActive(true);

                //panelTab[i].layer = 0;
               // panelTab[i].GetComponent<RectTransform>().localPosition = new Vector3(panelTab[i].GetComponent<RectTransform>().localPosition.x,panelTab[i].GetComponent<RectTransform>().localPosition.y,-1);

            }
            else
            {
                panelTab[i].SetActive(false);
                //panelTab[i].layer = 1;
                //panelTab[i].GetComponent<RectTransform>().localPosition = new Vector3(panelTab[i].GetComponent<RectTransform>().localPosition.x,panelTab[i].GetComponent<RectTransform>().localPosition.y,1);
                //panelTab[i].GetComponent<Renderer>().enabled = false;


            }


        }
    }
    
}
