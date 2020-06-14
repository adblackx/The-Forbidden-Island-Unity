using System;
using System.Collections.Generic;

namespace Tfi
{
    public class Explorateur:Player
    {
        public Explorateur(Zone zone, string canvasPath, Island modele) : base(zone, canvasPath, modele)
        {
        }
        
        public override List<Zone> zonesSafeToMove(){
            Position pos = base.zone.getPosition();
            List<Zone> zonesSafe = new List<Zone>();
            Zone [][] zones = modele.getGrille();

            int xMin ;
            int yMin ;
            int yMax ;
            int xMax ;

            xMin = getMin(pos.x);
            yMin = getMin(pos.y);
            yMax = getMax(pos.y, Island.HAUTEUR);
            xMax = getMax(pos.x,Island.LARGEUR);

            for(int i = xMin; i<=xMax; i++ )
            for(int j = yMin; j<=yMax; j++)
                if(zones[i][j].isSafe())
                    zonesSafe.Add(zones[i][j]);

            if(zone.isSafe())
                zonesSafe.Add(zone);

            return zonesSafe;
        }



        public static int getMin(int d){
            int res;

            if(d-1>=0){
                res=d-1;

            }
            else
                res=d;

            return res;
        }

        public static int getMax(int d, int MAX){
            int res;
            if(d+1<MAX){
                res=d+1;
            }
            else
                res=d;
            return res;
        }

        /**
     * Renvoie le role sous forme de chaine de caractère
     * @return
     */
        public override String toString() {
            return "Explorateur";
        }
        
        public override String getSpritePath()
        {
            return "Image/explorateur"; // sample example me saoule pas wola
        }
    }
}