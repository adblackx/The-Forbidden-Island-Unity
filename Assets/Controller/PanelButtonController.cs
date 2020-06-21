using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonController : MonoBehaviour
{
    private Island modele;
    public GameObject[] panelTab;
    public int panelActive;
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
        panelActive = 0;
        panelTab[panelActive].transform.SetAsLastSibling();

    }
    public void onButtonClickP1()
    {
        print("click p1");
        hideExcept(1);
        panelActive = 1;
        panelTab[panelActive].transform.SetAsLastSibling();

    }
    public void onButtonClickP2()
    {
        print("click p2");
        hideExcept(2);
        panelActive = 2;
        panelTab[panelActive].transform.SetAsLastSibling();

    }
    public void onButtonClickP3()
    {
        print("click p3");
        hideExcept(3);
        panelActive = 3;
        panelTab[panelActive].transform.SetAsLastSibling();

    }
    
    public void setPanelController(GameObject[] panelTab)
    {
        this.panelTab = panelTab;
    }

    public void setPanelActive(int panelActive)
    {
        this.panelActive = panelActive;
    }

    public void showOtherPanel(int indice)
    {
        for (int i = 0; i < panelTab.Length; i++)
        {
            if (i != indice && i != panelActive)
            {
                panelTab[i].GetComponent<PanelCardController>().setToInitPos();
                panelTab[i].SetActive(false);
            }
        }
        panelTab[indice].transform.localPosition = new Vector3(panelTab[indice].transform.localPosition.x,
            0,
            1);

        panelTab[indice].SetActive(true);
    }

    public void showPanel()
    {
        for (int i = 0; i < panelTab.Length; i++)
        {
            
            panelTab[i].GetComponent<PanelCardController>().setToInitPos();
            panelTab[i].SetActive(false);
            
        }
        
        panelTab[panelActive].SetActive(true);

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

        panelActive = indice;
    }
    
}
