using System;
using System.Collections;
using System.Collections.Generic;
using Tfi;

public class Zone
{
     /** On conserve un pointeur vers la classe principale du modèle. */
    
        /** L'état d'une cellule est donné par un booléen. */
        private Etat.EtatName etat;
        /** Artéfact caché dnas la zone*/
        private Artefacts artefacts;
        /** Bool pour savoir si la zone est la zone spéciale héliport*/
        private bool heliport;
        /** Position de la zone */
        private Position position;
    
        public Zone(Etat.EtatName etat, Position position,  Artefacts artefacts, bool heliport) {
            this.etat = etat;
            this.artefacts = artefacts;
            this.position = position;
            this.heliport = heliport;
        }
    
        // second constructeur pour set autre chose que l'heliort.
        public Zone(Etat.EtatName etat, Position position,  Artefacts artefacts) : this(etat, position, artefacts, false){
          
        }
    
    
        /**
         * @Description, on change la position de la Zone
         * */
        public void setPosition(Position p){
            this.position = p;
        }
    
        /**
         * @Description, on change l'etat de la zone
         * */
        public void setEtat(Etat.EtatName etat){
            this.etat = etat;
        }
    
        /*
        public void removeArtefacts(){
            this.artefacts = Artefacts.none;
        }*/
        /**
         * @Description geteur de la position
         * */
        public Position getPosition(){
            return this.position;
        }
    
        /**
         * @Description geteur l'artefact
         * */
        public Artefacts getArtefacts(){
            return this.artefacts;
        }
        /**
         * @Description geteur de l'etat
         * */
        public Etat.EtatName getEtat(){
            return this.etat;
        }
    
        /**
         * @Description geteur de l'artefact pour l'update
         * */
        public void setArtefacts(Artefacts artefacts) {
            this.artefacts = artefacts;
        }
    
        /**
         * @Description geteur de Heliport
         * */
        public bool isHeliport(){
            return this.heliport;
        }
    
        /**
         * @Description pour efficher le type de zone
         * */
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    
        /**
         * @Description test que c'est une zone non mortelle pour une joueur
         * @return une zone safe
         * */
        public bool isSafe(){
            return this.etat==Etat.EtatName.Normale || this.etat==Etat.EtatName.Inondee;
        }
        /**
         * @Description que c'est une zone inondee
         * @return true si la zone est inondee
         * */
        public bool isFlooded(){
            return this.etat == Etat.EtatName.Inondee;
        }
    
        /**
         * @Description getteur de la position x
         * */
        public int getX(){
            return position.x;
        }
        /**
         * @Description getteur de la position y
         * */
        public int getY(){
            return position.y;
        }
}
