using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.EventSystems;
using Tfi;
using UnityEngine.UI;

public class GridController : MonoBehaviour 
{
    private int nbLignes=6;
    private int nbColonnes=6;
    public static float tileSize = 150f; // taille des prefabs
    private Island modele;
    //public GameObject Panel;

    
    // Start is called before the first frame update
    void Start()
    {
           GenerateGrid();
           GameObject o1 = GameObject.Find("Canvas");
           Canvas  canvas =  o1.GetComponent<Canvas>(); // on chope le prefab ici
           float h = canvas.GetComponent<RectTransform>().rect.height; // exemple pour obtenir la taille du canvas contenant la grille
           //print(h);
           
    }

    private void GenerateGrid()
    {
        print("instance modele");
        modele = new Island();
        Zone [][] zones = modele.getZone();
        
        GameObject refr = (GameObject)Instantiate(Resources.Load("Prefabs/ZoneNormal")); // on chope le prefab ici
//        print(refr);
        for(int i =0; i<nbLignes; i++){
            for(int j =0; j<nbColonnes; j++){
                if (zones[i][j].getEtat() != Etat.EtatName.None) {
                    GameObject tile = (GameObject)Instantiate(refr, transform);
                    float posX = i * tileSize;
                    float posY = -j * tileSize;
                    //tile.transform.parent = transform;
                    //print("1 " +   tile.transform.localScale);
                    tile.transform.localScale =new Vector3(tileSize,tileSize, 0f);
                    //print("2 " +   tile.transform.localScale);
                    tile.transform.position = new Vector3(posX-386*2,posY,0);
                    tile.GetComponent<ZoneController>().SetZone(modele.getZone()[i][j]);
                    tile.GetComponent<ZoneController>().SetModele(modele);

                }
                
            }    

        }
        
        Destroy(refr);
        add4Player();
        modele.setRoundOf(modele.GetListPlayers()[0]);
        
        float gridW= tileSize*nbLignes;
        float gridH= tileSize*nbColonnes;
        transform.position = new Vector2(0-(gridW/2 - tileSize/2), 0+(gridH/2 - tileSize/2));
   
       /* GameObject[] gos = GameObject.FindGameObjectsWithTag("Panel");
        foreach (GameObject go in gos)
        {
            go.GetComponent<PanelController>().SetModele(modele);
        }*/
       
        GameObject hand = GameObject.Find("nextRound");
        print("trouve "+hand.name);
        hand.GetComponent<nextRoundController>().setModele(modele);

        hand = GameObject.Find("Panel(Canvas)");
        print("trouve "+hand.name);
        hand.GetComponent<PanelController>().setModele(modele);
    }
    
     public void buttonNextRound(){ // endroit provisoire ici on dépalcera dans un endroit ou on gérera tous les boutons si on veut
         modele.nextRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayerPrefabs(Player player)
    {
        GameObject prefabs = (GameObject) Instantiate(Resources.Load("Prefabs/Pawn"+player.toString()));
        GameObject pawn = (GameObject)Instantiate(prefabs, transform);
        Destroy(prefabs);
        pawn.transform.localScale = new Vector3(tileSize/2,tileSize/2,1);
        
        Transform originalParent = pawn.transform.parent;
        pawn.transform.SetParent(transform.parent.parent); //on change le parent pour avoir GridBackground en parent mieux pour calcul des coordonnées des pions
        //formule pour trouver les coord
        pawn.transform.localPosition = new Vector3(-tileSize*3  + player.getZone().getX()*tileSize + tileSize*0.25f, 
                                                    tileSize*3 - (player.getZone().getY())*tileSize - tileSize*0.25f,-1);
        //pawn.transform.SetParent(originalParent);
        //pawn.transform.position = new Vector3(player.GetX()*tileSize-386*2,-player.GetY()*tileSize,-1);
        pawn.GetComponent<PawnController>().SetPlayer(player);
    }
    
    public void add4Player()
    {
        List<Zone> safeZones = modele.GetRandomSafeZone(4);
        
        String imageURL = "uselessParameter..."; //On Pourrait peut être modifier pour passer le prefabs si besoin
        Player p = new Ingenieur(safeZones[0],imageURL, modele);
        modele.GetListPlayers().Add(p);
        addPlayerPrefabs(p);
        
        p = new Explorateur(safeZones[1],imageURL, modele);
        modele.GetListPlayers().Add(p);
        addPlayerPrefabs(p);
        
        p = new Plongeur(safeZones[2],imageURL, modele);
        modele.GetListPlayers().Add(p);
        addPlayerPrefabs(p);
        
        p = new Messager(safeZones[3],imageURL, modele);
        modele.GetListPlayers().Add(p);
        addPlayerPrefabs(p);

    }

    public Island getModele()
    {
        print("return model");
        return modele;
    }


}
