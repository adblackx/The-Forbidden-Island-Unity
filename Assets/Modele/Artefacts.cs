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
        
    }

    
    
}