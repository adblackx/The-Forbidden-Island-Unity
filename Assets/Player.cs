using System;
using System.Collections;
using UnityEngine;

namespace Tfi
{


    public class Player{

        protected Zone zone;
        protected ArrayList playerCards = new ArrayList();
        protected ArrayList playerCardsDragtgable = new ArrayList();
        public static int nbActionsRestant;
        protected Island modele;
        Color color ;

        public Player(Zone zone, Color color, Island modele){
            this.zone = zone;
            this.color = color;
            this.modele = modele;
        }


    }
}