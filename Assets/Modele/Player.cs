using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Tfi
{


    public class Player{

        protected Zone zone;
        protected List<TresorCard.TresorCardName> playerCards = new List<TresorCard.TresorCardName>();
        public static int nbActionsRestant;
        protected Island modele;
        String canvasPath;

        public Player(Zone zone, String canvasPath, Island modele){
            this.zone = zone;
            this.canvasPath = canvasPath;
            this.modele = modele;
        }
        
        /**
     * Deplace le joueur
     * @param z la zone ou le joueur
     */
    public void movePlayer(Zone z){
        this.zone = z;
    }

    /**
     * Depalce le joeur
     * @param z la zone a assécher
     */
    public void drainWaterZone(Zone z){
        z.setEtat(Etat.EtatName.Normale);
    }

    /**
     * Prendre un artefact de l'ile
     */
    public void takeArtefact(){
        int compteur = 0;
        Artefacts.ArtefactsName artefacts = zone.getArtefacts();
        foreach(TresorCard.TresorCardName t in playerCards)
            if(TresorCard.getArtefactsAssociated(t) == artefacts && artefacts != Artefacts.ArtefactsName.None)
                compteur++;
        if(compteur >= 4){
            zone.setArtefacts(Artefacts.ArtefactsName.None);
            modele.getListArtefacts().Add(artefacts);
            for (int i = 0; i < 4; i++)
                this.defausseCard(Artefacts.getKeyAssociated(artefacts));
        }else{
            Console.WriteLine("Not allow here !");
        }
    }

    
    
    /**
     *
     * @param tas le tas de carte tresors du modele
     * @param defausse defausse carte tresor du modele
     * @param island modele
     */
    public void searchKey(List<TresorCard.TresorCardName> tas, List<TresorCard.TresorCardName> defausse, Island island)
    {
        if (tas.Count == 0)
        {
            Island.Shuffle(defausse);
            tas.AddRange(defausse);
            defausse.Clear();
        }

        TresorCard.TresorCardName card = tas[0];

    if(card == TresorCard.TresorCardName.RisingWater) {
            Console.WriteLine(TresorCard.ToString(card));
            island.risingWater();
            defausse.Add(card);
            tas.Remove(card);
        }else{
            this.playerCards.Insert(0,card);
            Console.WriteLine(TresorCard.ToString(card));
            tas.Remove(card);
        }

        /**Situation où il est facile de prendre un artefact feu**/
        /*this.playerCards.add(0,TresorCard.clef_feu);
        this.playerCards.add(0,TresorCard.clef_feu);
        this.playerCards.add(0,TresorCard.clef_feu);
        this.playerCards.add(0,TresorCard.clef_feu);*/
    }


    /**
     * Rajoute une action au compte d'action du joueur
     */
    public void addAction(){
        if(nbActionsRestant <3){
            nbActionsRestant +=1;
        }
        else{
            Console.WriteLine("Mouvement interdit");
        }
    }

    /**Regarde si le joueur peut agir**/
    public bool canAct(){
        return nbActionsRestant <3;
    }

    /**Réinitialise le compte action pour le prochain joueur**/
    public void resetNbActionRestant(){
        nbActionsRestant = 0;
    }


    /**
     * Gestion de l'action de defausser son surplus de cartes au debut
     * de chque tour car selon les règles officiel un joueur ne peut
     * voir plus de 5 cartes dans sa mains
     * @param toDiscard Liste des indices des cartes à defausser dans la main du joueur
     */
    public void discardCard(List<int> toDiscard){
        List<TresorCard.TresorCardName> toRemove = new List<TresorCard.TresorCardName> ();
        foreach(int i in toDiscard){
            toRemove.Add(playerCards[i]);
        }

        for(int i = 0; i < toRemove.Count; i++){
            defausseCard(toRemove[i]);
        }

        modele.getDefausseTresorCard().AddRange(toRemove);
    }


    /**
     * Action de defausser une carte
     * @param card carte à defausser
     */
    public void defausseCard(TresorCard.TresorCardName card){
        if(this.removeCard(card))
            modele.addToDefausseCarteTresor(card);
    }

    /**
     * Supprime une carte de la main du joueur
     * @param card card à supprimer
     * @return true si une carte est supprimer false si non
     */
    public bool removeCard(TresorCard.TresorCardName card){
        for(int i = 0; i < this.playerCards.Count; i++){
            if(card == playerCards[i]){
                playerCards.RemoveAt(i);
                return  true;
            }
        }
        return false;
    }

    /**Renvoie le nombre de vrai carte donc sans les cartes empty
     * ces cartes sont necessaire pour le drag and drop des cartes
     * @return
     */
    public int nombreCarte(){
        int compteur = 0;
        foreach(TresorCard.TresorCardName card in this.playerCards)
            if (card != TresorCard.TresorCardName.Empty)
                compteur++;
        return compteur;
    }

    /**
     * @return une liste de zone sure où le joueur peut se deplacer
     */
    public List<Zone> zonesSafeToMove(){
        Position pos = zone.getPosition();
        List<Zone> zonesSafe = modele.getSafeZoneArround(this.zone);
        zonesSafe.Remove(this.zone);
        return  zonesSafe;
    }


    /**
     * @return une liste de zone innondé que le joueur peut assecher
     */
    public List<Zone> zonesDrainable(){
        List<Zone> zones = modele.getSafeZoneArround(this.zone);
        if(this.zone.isSafe())
            zones.Add(this.zone);
        return zones;
    }


    /**
     * Action de donner une carte à un autre joueurs
     * @param card carte à donner
     * @param player joueur qui reçoit la carte
     */
    public void giveCard(TresorCard.TresorCardName card, Player player){
        if(player.getZone() == this.zone) {
            this.removeCard(card);
            this.addAction();
            player.setCard(card);
        }
    }


/********* Setter Et Getter ********/


    /**
     * Gettter renvoyant le chemin d'accès à l'org.MyGame.image representant le joueur
     * @return
     */
    public String getImage(){
        return this.canvasPath;
    }

    /**
     * @return la zone où se trouve le joueurs
     */
    public Zone getZone(){
        return this.zone;
    }


    /**
     * Getter
     * @return ArrayList des cartes du joueurs
     */
    public List<TresorCard.TresorCardName> getCards(){
        return this.playerCards;
    }

    /**
     * Setter
     * @param c carte a rajouter à la main du joueur
     */
    public void setCard(TresorCard.TresorCardName c){
        playerCards.Insert(0,c);
    }
    
    /**
     * Renvoie le role sous forme de chaine de caractère
     * @return
     */
    public virtual String toString(){
        return "Player";
    }
    public virtual String getSpritePath()
    {

        return "Image/explorateur"; // sample example me saoule pas wola
        
    }
    
    public int GetX()
    {
        return this.zone.getX();
    }

    public int GetY()
    {
        return this.zone.getY();
    }
    
    }
}