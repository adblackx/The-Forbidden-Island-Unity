using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Tfi;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class DiscardController : MonoBehaviour
{
    // Start is called before the first frame update

    public static Player player;
    public static List<int> cardToDiscard = new List<int>();
    public static Transform MyText;
    
    void Start()
    {
        ConstructPrefabs();
    }

    // Update is called once per frame

    
    
    public void onButtonClick()
    {
        if (player.getCards().Count - cardToDiscard.Count < 6)
        {
            foreach (var VARIABLE in cardToDiscard)
            {
                print("indice : " + VARIABLE);   
            }
            player.discardCard(cardToDiscard);
            DiscardController.player = null;
            cardToDiscard.Clear();
            SceneManager.UnloadSceneAsync("Discard");
            
        }
    }

    public void ConstructPrefabs()
    {
        MyText = this.gameObject.GetComponent<Transform>().Find("message");
        int nbCardToDiscard = player.getCards().Count - cardToDiscard.Count;
        MyText.GetComponent<Text>().text = (player.toString() + ": veuillez defausser " + nbCardToDiscard + " cartes");
        for (int i = 0; i < player.getCards().Count; i++)
        {
            print(player.getCards()[i].ToString());
            Sprite sprite =  Resources.Load<Sprite>(Tfi.TresorCard.getSpritePath(player.getCards()[i]));
            GameObject refr = (GameObject)Instantiate(Resources.Load("Prefabs/CardToDiscard")); // on chope le prefab ici
            GameObject card = (GameObject)Instantiate(refr, transform);
            card.GetComponent<Image>().sprite = sprite;
            card.transform.localPosition =new Vector3(-200 + i * 150 ,0, -2f);
            card.GetComponent<DiscardCard>().SetCard(player.getCards()[i],i);
            Destroy(refr);
        }
    }
    
}
