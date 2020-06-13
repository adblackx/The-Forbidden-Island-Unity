using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCardController : MonoBehaviour
{
    private Island modele;
    private Tfi.Player p;
    private GameObject[] listCard;
    // Start is called before the first frame update
    void Start()
    {
        listCard = new GameObject[6];
        GameObject refr = (GameObject)Instantiate(Resources.Load("Prefabs/Card")); // on chope le prefab ici
       // GameObject card = (GameObject)Instantiate(refr, transform);
        for (int i = 0; i<5; i++ )
        {
            GameObject card = (GameObject)Instantiate(refr, transform);
            card.transform.position =new Vector3(360+(110)*i ,260f, -1f);
            listCard[i] = card;
        }
        Destroy(refr);
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < p.getCards().Count; i++)
        {
            if (i < 5)
            {
                Tfi.TresorCard.TresorCardName c = p.getCards()[i];
                Sprite sprite =  Resources.Load<Sprite>(Tfi.TresorCard.getSpritePath(c));
                Transform transformOfCard = listCard[i].GetComponent<Transform>().Find("CardObject");
                transformOfCard.GetComponent<Image>().sprite = sprite;
                listCard[i].GetComponent<CardController>().SetCardName(c);

            }
        }
       // print(p.getCards().Count);

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
