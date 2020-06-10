using System;
using System.Collections.Generic;

namespace Tfi
{
    public class Navigateur:Player
    {
        public Navigateur(Zone zone, string canvasPath, Island modele) : base(zone, canvasPath, modele)
        {
        }
        /**
     *Renvoie les zones accessible pau navigateur
     * @param modele
     * @param pos
     * @return
     */
        public static List<Zone> zonesReachableNavigateur(Island modele, Position pos ){
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
                if(zones[i][pos.y].isSafe())
                    zonesSafe.Add(zones[i][pos.y]);

            for(int j = yMin; j<=yMax; j++)
                if(zones[pos.x][j].isSafe())
                    zonesSafe.Add(zones[pos.x][j]);

            return zonesSafe;
        }

        public static int getMin(int d){
            int res;
            if(d-2>=0){
                res=d-2;
            }
            else if(d-1>=0){
                res=d-1;

            }
            else
                res=d;

            return res;
        }

        public static int getMax(int d, int MAX){
            int res;
            if(d+2<MAX){
                res=d+2;
            }
            else if(d+1<MAX){
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
        public String toString() {
            return "Navigateur";
        }
    }
}