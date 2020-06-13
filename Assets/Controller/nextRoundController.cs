using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRoundController : MonoBehaviour
{
    private Island modele;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextRound()
    {
        modele.nextRound();
    }

    public void setModele(Island modele)
    {
        this.modele = modele;
    }
}
