using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Tfi;
public class GridController : MonoBehaviour 
{
    private int nbLignes=6;
    private int nbColonnes=6;
    private float tileSize = 2f; // taille des prefabs
    
    // Start is called before the first frame update
    void Start()
    {
           GenerateGrid();
           GameObject o1 = GameObject.Find("Canvas");
           Canvas  canvas =  o1.GetComponent<Canvas>(); // on chope le prefab ici
           float h = canvas.GetComponent<RectTransform>().rect.height;
           print(h);
    }

    private void GenerateGrid()
    {
        Island modele = new Island();
        Zone [][] zones = modele.getZone();
        GameObject refr = (GameObject)Instantiate(Resources.Load("Prefabs/ZoneNormal")); // on chope le prefab ici
        print(refr);
        for(int i =0; i<nbLignes; i++){
            for(int j =0; j<nbColonnes; j++){
                if (zones[i][j].getEtat() != Etat.EtatName.None) {
                    GameObject tile = (GameObject)Instantiate(refr, transform);
                    float posX = i * tileSize;
                    float posY = -j * tileSize;
                    //tile.transform.parent = transform;
                    //print("1 " +   tile.transform.localScale);
                    //tile.transform.localScale =new Vector3(0.9f,0.9f, 1.0f);
                    //print("2 " +   tile.transform.localScale);
                    tile.transform.position = new Vector3(posX,posY,0);

                }
                
            }    

        }
        
        Destroy(refr);

        float gridW= tileSize*nbLignes;
        float gridH= tileSize*nbColonnes;
        transform.position = new Vector2(0-(gridW/2 - tileSize/2), 0+(gridH/2 - tileSize/2));
        

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


}
