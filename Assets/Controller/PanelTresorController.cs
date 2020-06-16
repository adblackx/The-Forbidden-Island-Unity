using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTresorController : MonoBehaviour
{
    private Island modele;

    private int nmbTresor;
    // Start is called before the first frame update
    
    public void SetModele(Island modele)
    {
        this.modele = modele;
    }
    void Start()
    {
        nmbTresor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (modele.getListArtefacts().Count > nmbTresor)
        {
            nmbTresor += 1;
            
        }
    }

    public void updateAffichage()
    {
        
    }
}
