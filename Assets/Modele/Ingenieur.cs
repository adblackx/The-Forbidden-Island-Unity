using System;

namespace Tfi
{
    public class Ingenieur:Player

    {
        private int nbDrain = 0; //On garde en mémoire le nombre de zones asséché puis on le soustrait modulo 2 au nombre d'action réalisé
        
        public Ingenieur(Zone zone, string canvasPath, Island modele) : base(zone, canvasPath, modele)
        {
            
        }


        /**
     *
     * @param z la zone a assécher
     */
        public void drainWaterZone(Zone z) {
            this.nbDrain++;
            base.drainWaterZone(z);
            if(nbDrain%2 == 0)
                Ingenieur.nbActionsRestant--;
        }

        /**
     * Renvoie le role sous forme de chaine de caractère
     * @return
     */
        public override String toString() {
            return "Ingenieur";
        }
        
        public override String getSpritePath()
        {
            return "Image/ingenieur"; // sample example me saoule pas wola
        }
    }
}