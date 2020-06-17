using System;
using Tfi;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class DiscardCard : MonoBehaviour
    {
        private TresorCard.TresorCardName cardName ;
        private bool isSelect = false;
        private int indice;

        public void Update()
        {
            
        }

        public void SetCard(TresorCard.TresorCardName cardName, int indice)
        {
            this.cardName = cardName;
            this.indice = indice;
        }
        

        public int GetIndice()
        {
            return this.indice;
        }
        

        public bool GetIsSelect()
        {
            return this.isSelect;
        }

        public void OnMouseDown()
        {
            isSelect = !isSelect;
            if (!isSelect)
            {
                transform.GetComponent<Image>().color = Color.white;
                DiscardController.cardToDiscard.Remove(indice);
                int nbCardToDiscard = DiscardController.player.getCards().Count - DiscardController.cardToDiscard.Count - 5;
                if (nbCardToDiscard < 0)
                    nbCardToDiscard = 0;
                DiscardController.MyText.GetComponent<Text>().text = (DiscardController.player.toString() + ": veuillez defausser " + nbCardToDiscard + " cartes");
            }
            else
            {
                transform.GetComponent<Image>().color = Color.grey;
                DiscardController.cardToDiscard.Add(indice);
                int nbCardToDiscard = DiscardController.player.getCards().Count - DiscardController.cardToDiscard.Count - 5;
                if (nbCardToDiscard < 0)
                    nbCardToDiscard = 0;
                DiscardController.MyText.GetComponent<Text>().text = (DiscardController.player.toString() + ": veuillez defausser " + nbCardToDiscard + " cartes");
            }
            
            print("test discard clique");
        }
    }
}