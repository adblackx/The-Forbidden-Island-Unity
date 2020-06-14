using System;
using System.Collections.Generic;
using System.Linq;

namespace Tfi
{
    public class Pilote:Player
    {
        public bool canFly = true;
        
        public Pilote(Zone zone, string canvasPath, Island modele) : base(zone, canvasPath, modele)
        {
        }
        
        /**
     * Si la capacité spéciale du joueur est actif les zones où il peut se depalcer différents
     * @return zones où peut se rendre le joueur
     */
        public override List<Zone> zonesSafeToMove() {
            if(canFly){
                return modele.getSafeZones();
            }else
                return base.zonesSafeToMove();
        }


        /**
     * On regarde si le mouvement effectuer par le joueur à necessiter sa capacitée spéciale
     * @param zone zone ou veut aller le joueur
     * @return renvoie true si le joueur utilise sont atout false si non
     */
        public bool isFlying(Zone zone){
            List<Zone> zones = modele.getSafeZones();
            zones = zones.Except(base.zonesSafeToMove()).ToList();
            return zones.Contains(zone);
        }

        /**
     * @param z la zone ou le joueur
     */
        public override void movePlayer(Zone z) {
            if(isFlying(z))
                this.canFly = false; //Si le mouvement est distant on empeche d'utiliser une seconde fois le vol
            base.movePlayer(z);
        }

        /**On le réécrit pour remettre l'attribut canFly à 0 pour le prochain tour**/
        public override void searchKey(List<TresorCard.TresorCardName> tas, List<TresorCard.TresorCardName> defausse, Island island) {
            base.searchKey(tas, defausse, island);
            this.canFly = true;  //On remet canFly à jour
        }



        /**
     * Renvoie le role sous forme de chaine de caractère
     * @return
     */
        public override String toString() {
            return "Pilote";
        }
        
        public override String getSpritePath()
        {
            return "Image/pilote"; // sample example me saoule pas wola
        }
        
    }
}