using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonController : MonoBehaviour
{
    private GameObject[] panelTab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(i==indice)
                panelTab[i].SetActive(true);
            else
            {
                panelTab[i].SetActive(false);

            }

        }
    }
    
}
