using System;

namespace Tfi
{
    public class Messager:Player
    {
        public Messager(Zone zone, string canvasPath, Island modele) : base(zone, canvasPath, modele)
        {
        }
        
        /**
     * On modifie pour que le messager ne soit limiter spacialement pour donner ses cartes
     * @param card carte à donner
     * @param player joueur qui reçoit la carte
     */
        public void giveCard(TresorCard.TresorCardName card, Player player) {
            this.removeCard(card);
            this.addAction();
            player.setCard(card);
        }


        /**
     * Renvoie le role sous forme de chaine de caractère
     * @return
     */
        public String toString() {
            return "Messager";
        }
    }
}