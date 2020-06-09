using System;

namespace Tfi
{
    public class Etat
    {
        public enum EtatName
        {
            None,Normale,Inondee,Submergee
        }
        
        public static String GetString( Tfi.Etat.EtatName s1)
        {
            switch (s1)
            {
                case Tfi.Etat.EtatName.None:
                    return "Yeah!";
                case Tfi.Etat.EtatName.Normale:
                    return "Okay!";
                default:
                    return "What?!";
            }
        }
        
    }

    
    
}

