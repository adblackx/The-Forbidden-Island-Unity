using System;

namespace Tfi
{
    public class Artefacts
    {
        public enum ArtefactsName
        {
            Air, Eau, Feu, Terre, None
        }
        
        public static TresorCard.TresorCardName getKeyAssociated(ArtefactsName n){
            switch(n) {
                case ArtefactsName.Air:
                    return TresorCard.TresorCardName.ClefAir;
                case ArtefactsName.Eau:
                    return TresorCard.TresorCardName.ClefEau;
                case ArtefactsName.Feu:
                    return TresorCard.TresorCardName.ClefFeu;
                case ArtefactsName.Terre:
                    return TresorCard.TresorCardName.ClefTerre;
                default:
                    return TresorCard.TresorCardName.Empty;
            }
        }
        
        public static String getSpritePath(ArtefactsName etat){

            switch(etat) {
                case ArtefactsName.Air:
                    return "Image/vent";
                case ArtefactsName.Eau:
                    return "Image/eau";
                case ArtefactsName.Feu:
                    return "Image/feu";
                case ArtefactsName.Terre:
                    return "Image/terre";
                default:
                    return "Image/None";
            }
        }
        
        public static String toString(ArtefactsName etat){

            switch(etat) {
                case ArtefactsName.Air:
                    return "air";
                case ArtefactsName.Eau:
                    return "eau";
                case ArtefactsName.Feu:
                    return "feu";
                case ArtefactsName.Terre:
                    return "terre";
                default:
                    return "Image/None";
            }
        }
        
    }

    
    
}