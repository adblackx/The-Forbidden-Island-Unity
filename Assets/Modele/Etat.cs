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
                case EtatName.Inondee:
                    return "Inondee";
                case EtatName.Normale:
                    return "Normal";
                case EtatName.Submergee:
                    return "Subrmergee";
                default:
                    return "None";
            }
        }
        
    }

    
    
}

