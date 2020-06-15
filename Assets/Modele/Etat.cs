using System;

namespace Tfi
{
    public class Etat
    {
        public enum EtatName
        {
            None,Normale,Inondee,Submergee
        }
        
        public static String GetString(EtatName s1)
        {
            switch (s1)
            {
                case EtatName.Normale:
                    return "Normal";
                case EtatName.Inondee:
                    return "Inondee";
                case EtatName.Submergee:
                    return "Subrmergee";
                default:
                    return "None";
            }
        }
        
        public static Etat.EtatName nextEtat(Etat.EtatName etat){

            switch (etat)
            {
                case EtatName.Normale:
                    return EtatName.Inondee;
                case EtatName.Inondee:
                    return EtatName.Submergee;
                case EtatName.Submergee:
                    return EtatName.Submergee;
                default:
                    return EtatName.None;
            }
        }
        
        public static String getSpritePath(Etat.EtatName etat){

            switch (etat)
            {
                case EtatName.Normale:
                    return "Image/normal";
                case EtatName.Inondee:
                    return "Image/innonde";
                case EtatName.Submergee:
                    return "Image/submerge";
                default:
                    return "Image/None";
            }
        }
        
    }

    
    
}

