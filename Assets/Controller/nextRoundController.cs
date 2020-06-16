using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRoundController : MonoBehaviour
{
    private Island modele;
    PanelButtonController pbc ;
    
    // Start is called before the first frame update
    void Start()
    {
        pbc =  GameObject.Find("Panel(Canvas)").transform.Find("PanelAllButtons").GetComponent<PanelButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextRound()
    {
        modele.nextRound();
        int indice = modele.GetListPlayers().IndexOf(modele.getRoundOf());
        pbc.hideExcept(indice);
        pbc.panelActive = indice;
    }

    public void setModele(Island modele)
    {
        this.modele = modele;
    }
}
