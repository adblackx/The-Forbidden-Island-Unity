using System;

namespace Tfi
{
    public class TresorCard
    {
        public enum TresorCardName
        {
            ClefAir, ClefEau, ClefFeu, ClefTerre, Helicopter, Sandbag, RisingWater, Empty
        }

        public static string ToString(TresorCardName s1)
        {
            switch (s1)
            {
                case TresorCardName.Helicopter:
                    return "Helicopter";
                case TresorCardName.Sandbag:
                    return "Sandbag";
                case TresorCardName.ClefAir:
                    return "Clef Air";
                case TresorCardName.ClefEau:
                    return "Clef Eau";
                case TresorCardName.ClefFeu:
                    return "Clef Feu";
                case TresorCardName.ClefTerre:
                    return "Clef Terre";
                default:
                    return "Empty";
            }
        }
        
        public static Artefacts.ArtefactsName getArtefactsAssociated(TresorCardName n)
        {
            switch(n) {
                case TresorCardName.ClefAir:
                    return Artefacts.ArtefactsName.Air;
                case TresorCardName.ClefEau:
                    return Artefacts.ArtefactsName.Eau;
                case TresorCardName.ClefFeu:
                    return Artefacts.ArtefactsName.Feu;
                case TresorCardName.ClefTerre:
                    return Artefacts.ArtefactsName.Terre;
                default:
                    return Artefacts.ArtefactsName.None;
            }
        }
        
        public static String getSpritePath(TresorCardName n)
        {
            switch(n) {
                case TresorCardName.ClefAir:
                    return "Image/clef_vent";
                case TresorCardName.ClefEau:
                    return "Image/clef_eau";
                case TresorCardName.ClefFeu:
                    return "Image/clef_feu";
                case TresorCardName.ClefTerre:
                    return "Image/clef_terre";
                default:
                    return "Image/clef_vide";
                }
        }
    }
}