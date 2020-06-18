using System.Collections;
using System.Collections.Generic;
using Tfi;
using UnityEngine;
using UnityEngine.UI;

public class TakeTresorController : MonoBehaviour
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
    
    public void setModele(Island modele)
    {
        this.modele = modele;
    }
    
    public void OnClick()
    {
        
        Player p = modele.getRoundOf();
        for(int i = 0; i < 4; i++)
            p.getCards().Add((TresorCard.TresorCardName.ClefFeu));
        bool haveTake = false;
        if (p.canAct())
        {
            Artefacts.ArtefactsName artefacts = p.getZone().getArtefacts();
            if (p.takeArtefact())
            {
                p.addAction();
                GameObject g = GameObject.Find(Artefacts.toString(artefacts));
                print("trouve "+g.name);
                Texture sprite =  Resources.Load<Texture>(Artefacts.getSpritePath(artefacts));
                g.GetComponent<RawImage>().texture = sprite;
                g.GetComponent<RawImage>().material = null;
            }
                
        }
        
    }
}
