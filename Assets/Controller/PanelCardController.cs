using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCardController : MonoBehaviour
{
    private Island modele;
    private Tfi.Player p;
    private GameObject[] Array;
    // Start is called before the first frame update
    void Start()
    {
        Array = new GameObject[6];
        GameObject refr = (GameObject)Instantiate(Resources.Load("Prefabs/Card")); // on chope le prefab ici
       // GameObject card = (GameObject)Instantiate(refr, transform);
        for (int i = 0; i<5; i++ )
        {
            GameObject card = (GameObject)Instantiate(refr, transform);
            card.transform.position =new Vector3(360+(110)*i ,214f, 0f);

        }
        Destroy(refr);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void SetModele(Island modele)
    {
        this.modele = modele;
    }

    public void setPlayer(Tfi.Player p)
    {
        this.p = p;
    }
}
