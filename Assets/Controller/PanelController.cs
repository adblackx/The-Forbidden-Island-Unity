using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private Island modele;

    public GameObject grille;
    private GameObject[] panelTab= new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
        print("appel de get modele");
        modele = GameObject.Find("Grille").GetComponent<GridController>().getModele(); // on chope le modele//*modele = grille.GetComponent<GridController>().getModele();
        GameObject pane = (GameObject)Instantiate(Resources.Load("Prefabs/Panel")); // on chope le prefab ici
        pane.GetComponent<PanelCardController>().SetModele(modele);
        print(modele);
        int lenght = modele.GetListPlayers().Count;
        for (int i = 0; i < lenght ; i++)
        {
            GameObject panel = (GameObject)Instantiate(pane, transform);
            panel.GetComponent<PanelCardController>().setPlayer(modele.GetListPlayers()[i]);
            panel.transform.localPosition = new Vector3(0,-i*214f + 214f,0);
            panelTab[i] = panel;
            if(i!=0)
                panelTab[i].SetActive(false);
        }
        
        Destroy(pane);

        // ici on doit in,stancier les panels + ajouter les joueurs
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
