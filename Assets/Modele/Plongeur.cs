using System;
using System.Collections.Generic;

namespace Tfi
{
    public class Plongeur:Player
    {
        public Plongeur(Zone zone, string canvasPath, Island modele) : base(zone, canvasPath, modele)
        {
        }
        
        /**
     * @return zone ou le joueur peut se depalcer
     */
        public List<Zone> zonesSafeToMove() {
            List<Zone> zonesReachable = new List<Zone>();
            searchRoad(zonesReachable, this.zone);
            zonesReachable.AddRange(base.zonesSafeToMove());
            return zonesReachable;
        }


        /**
     * Calcul recursif les tuiles où le joueurs peut avancer grâce à sa capacité spéciale
     * @param zonesReachable list des zones à updates
     * @param zone zone à partir de laquelle ont regarde les zones accessibles
     */
        private void searchRoad(List<Zone> zonesReachable, Zone zone){
            foreach(Zone z in modele.getZoneArround(zone)){
                if(!zonesReachable.Contains(z)){
                    if (zone.getEtat() == Etat.EtatName.Inondee || zone.getEtat() == Etat.EtatName.Normale) {
                        zonesReachable.Add(zone);
                        if (zone.getEtat() == Etat.EtatName.Inondee || zone.getEtat() == Etat.EtatName.Submergee) {
                            searchRoad(zonesReachable, z);
                        }
                    }

                }
            }
        }


        /**
     * Renvoie le role sous forme de chaine de caractère
     * @return
     */
        public override String toString() {
            return "Plongeur";
        }
        
        public override String getSpritePath()
        {
            return "Image/plongeur"; // sample example me saoule pas wola
        }
        
    }
}