using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    private Island modele;

    public GameObject grille;
    private GameObject[] panelTab;
    // Start is called before the first frame update
    void Start()
    {
        
        print("appel de get modele");
        modele = GameObject.Find("Grille").GetComponent<GridController>().getModele(); // on chope le modele//*modele = grille.GetComponent<GridController>().getModele();
        GameObject pane = (GameObject)Instantiate(Resources.Load("Prefabs/Panel")); // on chope le prefab ici
        pane.GetComponent<PanelCardController>().SetModele(modele);
        print(modele);
        int lenght = modele.GetListPlayers().Count;
        panelTab = new GameObject[lenght];
        for (int i = lenght-1; i >= 0 ; i--)
        {
            GameObject panel = (GameObject)Instantiate(pane, transform);
            panel.GetComponent<PanelCardController>().setPlayer(modele.GetListPlayers()[i]);
            panel.GetComponent<PanelCardController>().SetModele(modele);
            panel.GetComponent<PanelCardController>().setInitPos( new Vector3(0,214f ,0));
            panel.transform.localPosition = new Vector3(0,214f ,0);
            
            Transform transformOfCard = panel.GetComponent<Transform>().Find("Icone");
            Sprite sprite =  Resources.Load<Sprite>(modele.GetListPlayers()[i].getSpritePath());
            transformOfCard.GetComponent<Image>().sprite = sprite;
            
            panelTab[i] = panel;
            

            String tag = "ButPlayer" + (i+1);
            GameObject hand = GameObject.Find(tag);
            print("trouve " + tag +" "+ hand.name);
            hand.transform.GetChild(0).GetComponent<Text>().text = modele.GetListPlayers()[i].toString();
            
            if(i!=0)
                panelTab[i].SetActive(true);
        }
        // TODO CACHER LES BOUTONS EN TROP QUAND ON AURA MOINS DE 4 JOUEURS, EASY A FAIRE MAIS JE VEUXC ME REPOSER WOLA ++
        
        
        
        GameObject.Find("PanelAllButtons").GetComponent<PanelButtonController>().setPanelController(panelTab);
        
        Transform t = GameObject.Find("PanelAllButtons").GetComponent<Transform>();

        int compteur=0;
        foreach (Transform eachChild in t)
        {
            print(eachChild.name);
            if (compteur < 4-lenght)
            {
                //Destroy(eachChild.GetComponent<GameObject>());
                Destroy(eachChild.gameObject);
                print("ENFAAAAAAAAAAAAAAAAAAAAAAANNNNNNNNNNNNNNNNTTTT " + eachChild.name);
                
            }
            
            compteur++;
        }

        Destroy(pane);
        
       /* GameObject hand = GameObject.Find("ButPlayer1");
        print("trouve " + hand.name);
        hand.transform.GetChild(0).GetComponent<Text>().text = modele.GetListPlayers()[0].toString();

        for (int i = 0; i < 4; i++)
        {
            String tag = "ButPlayer" + (i+1);
            hand = GameObject.Find(tag);
            print("trouve " + tag +" "+ hand.name);
            hand.transform.GetChild(0).GetComponent<Text>().text = modele.GetListPlayers()[i].toString();
        }*/
       
       /*GameObject hand = GameObject.Find("ButPlayer1");
        hand.transform.GetChild(0).GetComponent<Text>().text = modele.GetListPlayers()[0].toString();
        print("trouve "+hand.name);*/
        
        /*hand.transform.GetChild(0).GetComponent<Text>().text = modele.GetListPlayers()[0].toString();
        print("trouve "+hand.name);*/

        // ici on doit in,stancier les panels + ajouter les joueurs

    }
    
    public void setModele(Island modele)
    {
        this.modele = modele;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
