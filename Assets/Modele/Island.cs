using System;
using System.Collections;
using System.Collections.Generic;
using Tfi;
using System.Collections;
using System.Security.Cryptography;

public class Island
{
    

    /** On fixe la taille de la grille. */
    public static readonly int HAUTEUR=6, LARGEUR=6;
    /** On stocke un tableau de cellules. */
    public Zone[][] zones;
    /** C'est un pointeur vers player qui a un tour **/
    private Player RoundOf;
    /*Liste des Players*/
    private readonly List<Player> listPlayers = new List<Player> ();
    /*Liste des Artefacts*/
    private readonly List<Artefacts.ArtefactsName> listArtefacts = new List<Artefacts.ArtefactsName>();
    /*Liste de la pioche*/
    private List<TresorCard.TresorCardName> tasCarteTresor = new List<TresorCard.TresorCardName>();
    /*Liste de la défausse*/
    private List<TresorCard.TresorCardName> defausseCarteTresor = new List<TresorCard.TresorCardName>();
    /*Liste de la pioche Inondation*/
    private List<Zone> tasCarteInnondation = new List<Zone>();
    /*Liste de la défausse inondation*/
    private List<Zone> defausseCarteInnondation = new List<Zone>();
    /*Indicateur du niveau de la montée des eaux*/
    private int seaLevel = 1;

    /*Indicateur du nombre de carte à piocher*/
    private int numberCardToPick = 2;
    /*boolean qui nous permet de savoir qui la fin du jeu est actée, permettant d'afficher l'écran de fin*/
    private bool endOfGame = false;
    /*boolean qui permet de tester la fin du jeu à l'aide d'une carte helicoptere*/
    private bool testEndOfGame = false;
    
    /** Construction : on initialise notre grille */
    public Island() {
        /*
          On initialise la grille, on met tous les état à None
         
         */
        zones = new Zone[LARGEUR][];
        for(int i=0; i<LARGEUR; i++) {
            zones[i] = new Zone[HAUTEUR];
            for(int j=0; j<HAUTEUR; j++) {
                zones[i][j] = new Zone(Etat.EtatName.None, new Position(i,j), Artefacts.ArtefactsName.None);
            }
        }
        init();

    }
    
    /**
     * @Initialisation aléatoire de la grille
     * on calcule la croix de la grille
     */

    public void init() {

        initTasCarteInnondation();
        initTasCarteTresor();

        for(int j=0; j<=HAUTEUR; j++) { // on calcule les coordonées en augmentant et diminuant les i et j
            int j_p;
            if (j >= HAUTEUR/2)
                j_p = HAUTEUR -1 - j;
            else
                j_p = j;
            for(int i= LARGEUR/2   - j_p%(HAUTEUR/2) - 1; i<=LARGEUR/2 + j_p%(HAUTEUR/2) ; i++) {
                Zone z = tasCarteInnondation[0];
                z.setPosition(new Position(i,j));
                zones[i][j] = z;
                defausseCarteInnondation.Add(z);
                tasCarteInnondation.Remove(z);
            }
        }

        /***On retransfert toutes les cartes**/
        
        Island.Shuffle(defausseCarteInnondation);
        tasCarteInnondation.AddRange(defausseCarteInnondation);
        defausseCarteInnondation.Clear();


    }
    
    /**
    * @Description On initialise le tas Inondation
     */
    private void initTasCarteInnondation(){
        tasCarteInnondation.Add(new Zone(Etat.EtatName.Normale, new Position(0,0), Artefacts.ArtefactsName.None,true));
        for(int i = 0; i < 2; i++) {
            tasCarteInnondation.Add(new Zone(Etat.EtatName.Normale, new Position(0,0), Artefacts.ArtefactsName.Feu));
            tasCarteInnondation.Add(new Zone(Etat.EtatName.Normale, new Position(0,0), Artefacts.ArtefactsName.Eau));
            tasCarteInnondation.Add(new Zone(Etat.EtatName.Normale, new Position(0,0), Artefacts.ArtefactsName.Terre));
            tasCarteInnondation.Add(new Zone(Etat.EtatName.Normale, new Position(0,0), Artefacts.ArtefactsName.Air));
        }

        for(int i = 0; i < 15; i++){
            tasCarteInnondation.Add(new Zone(Etat.EtatName.Normale, new Position(0,0), Artefacts.ArtefactsName.None));
        }
       // Collections.shuffle(tasCarteInnondation); //Pour mélanger
    }
    
    /**
     * @Description On initialise le tas Inondation CarteTresor
     */
    private void initTasCarteTresor(){

        //3 * Chaque Cartes spéciale
        for(int i = 0; i < 3; i++){
            tasCarteTresor.Add(TresorCard.TresorCardName.Helicopter);
            tasCarteTresor.Add(TresorCard.TresorCardName.Sandbag);
            tasCarteTresor.Add(TresorCard.TresorCardName.RisingWater);
        }

        //5 * Clé pour chaque artefacts
        for(int i = 0; i < 5; i++){
            tasCarteTresor.Add(TresorCard.TresorCardName.ClefAir);
            tasCarteTresor.Add(TresorCard.TresorCardName.ClefEau);
            tasCarteTresor.Add(TresorCard.TresorCardName.ClefFeu);
            tasCarteTresor.Add(TresorCard.TresorCardName.ClefTerre);
        }
        
        Island.Shuffle(tasCarteTresor);
    }
    
    private void addPlayer(String c){
        int[] tab = getRandomPoint();
        Player p = new Player(zones[tab[0]][tab[1]],c, this);
        this.listPlayers.Add(p);
    }

    //Todo: A tester peut bugger

    /**
    * @Description qui renvoie les coordonnées dans un tab
    * de trois zones à modifier se situant dans la croix
    */
    public int[] getRandomPoint(){
        Random randomGen = new Random();
        int[] tab= new int[2];
        int j = randomGen.Next(HAUTEUR);
        int j_p;
        if (j >= HAUTEUR/2)
            j_p = HAUTEUR -1 - j;
        else
            j_p = j;

        int indic = LARGEUR/2 + j_p%(HAUTEUR/2) + 1 - (LARGEUR/2   - j_p%(HAUTEUR/2) - 1);
        int i = LARGEUR/2   - j_p%(HAUTEUR/2) - 1 + randomGen.Next( indic);
        tab[0] = i;
        tab[1] = j;
        return tab;
    }

    /**
     * @Description est appellée par un controlleur pour changer de round
     * On procède en deux étapes.
     *  - D'abord, pour chaque cellule on évalue ce que sera son état à la
     *    prochaine génération.
     *  - Ensuite, on applique les évolutions qui ont été calculées.
     */
    public void nextRound() {


        for(int i = 0; i < numberCardToPick; i++){ // on pioche un certain nombre de carte
            if(tasCarteInnondation.Count + defausseCarteInnondation.Count > 0) {
                if (tasCarteInnondation.Count == 0) { //si tas vide on remet la defausse dans le tas
                    Island.Shuffle(defausseCarteInnondation); //on melange avant
                    tasCarteInnondation.AddRange(defausseCarteInnondation);
                    defausseCarteInnondation.Clear();
                }
                Zone z = tasCarteInnondation[0]; // on pioche la carte ( mise à jour de la zone )
                Etat.EtatName etat = z.getEtat();
                z.setEtat(Etat.nextEtat(etat));
                if (z.getEtat() != Etat.EtatName.Submergee)
                    defausseCarteInnondation.Add(z); // defausse la carte
                tasCarteInnondation.Remove(z); // on retire la carte
            }
        }

        
        RoundOf.searchKey(this.tasCarteTresor, this.defausseCarteTresor, this);
        RoundOf.searchKey(this.tasCarteTresor, this.defausseCarteTresor, this);

        //displayLose();

        /*listArtefacts.add(Artefacts.eau);
        listArtefacts.add(Artefacts.eau);
        listArtefacts.add(Artefacts.feu);
        listArtefacts.add(Artefacts.air);*/

        //mise à jour du prochain joueur
        List<Player> players = this.listPlayers;
        this.setRoundOf(players[(players.IndexOf(this.getRoundOf())+1)%players.Count]);
        
        //notifyObservers();
    }


    public void setRoundOf(Player p)
    {
        this.RoundOf = p;
        p.resetNbActionRestant();
        
    }

    public Player getRoundOf()
    {
        return this.RoundOf;
    }

    public Zone[][] getZone()
    {
        return this.zones;
    }

    public List<TresorCard.TresorCardName> getDefausseTresorCard()
    {
        return this.defausseCarteTresor;
    }

    public void addToDefausseCarteTresor(TresorCard.TresorCardName card)
    {
        this.defausseCarteTresor.Add(card);
    }

    public List<Artefacts.ArtefactsName> getListArtefacts()
    {
        return this.listArtefacts;
    }
    
    /**
    * @Description on cherche les zones safes dans la grille
     * cette fonction sert autirage
     */
    public List<Zone> getSafeZones(){
        List<Zone> safeZones = new List<Zone>();
        safeZones.AddRange(tasCarteInnondation);
        safeZones.AddRange(defausseCarteInnondation);
        return safeZones;
    }
    
    /**
     * @Description on cherche les zones haut bas gauche droite dans la grille
     * @param zone une zone dans la grille zones
     * @return une liste de Zone
     */
    public List<Zone> getZoneArround(Zone zone){
        List<Zone> voisins = new List<Zone>();
        Position pos = zone.getPosition();
        if (pos.y-1>=0)
            voisins.Add(zones[pos.x][pos.y-1]);
        if(pos.x-1>=0)
            voisins.Add(zones[pos.x-1][pos.y]);

        if(pos.y+1<Island.HAUTEUR)
            voisins.Add(zones[pos.x][pos.y+1]);

        if(pos.x+1<Island.LARGEUR)
            voisins.Add(zones[pos.x+1][pos.y]);

        voisins.Add(zone);
        return voisins;
    }
    
    public List<Zone> getSafeZoneArround(Zone zone)
    {
        List<Zone> voisins = new List<Zone>();
        Position pos = zone.getPosition();
        if (pos.y-1>=0)
            voisins.Add(zones[pos.x][pos.y-1]);
        if(pos.x-1>=0)
            voisins.Add(zones[pos.x-1][pos.y]);

        if(pos.y+1<Island.HAUTEUR)
            voisins.Add(zones[pos.x][pos.y+1]);

        if(pos.x+1<Island.LARGEUR)
            voisins.Add(zones[pos.x+1][pos.y]);

        voisins.Add(zone);
        return voisins;
    }

    public void risingWater()
    {
        this.seaLevel= 1+(this.seaLevel)%11;
        if(this.seaLevel > 7)
            this.numberCardToPick = 5;
        else if(this.seaLevel > 5)
            this.numberCardToPick = 4;
        else if(this.seaLevel > 2)
            this.numberCardToPick = 3;
        else
            this.numberCardToPick = 2;
        Console.WriteLine(seaLevel);
        Console.WriteLine(this.numberCardToPick + " card to pick");
    }
    
    public bool Win() {
        if (testEndOfGame) { // test si on utilisé la carte heliport
            Player p1 = listPlayers[0];
            if (!p1.getZone().isHeliport())
                return false;


            foreach (Player p in listPlayers) { // les joueurs doivent être sur la même zone
                if (!p1.getZone().Equals(p.getZone()))
                    return false;
                p1 = p;
            }
            if(haveFourElements())
                return true;

            testEndOfGame = false; // si le test échoue on retourne à false

        }

            return false;
    }

        public bool haveFourElements(){

            return listArtefacts.Contains(Artefacts.ArtefactsName.Air) &&
                    listArtefacts.Contains(Artefacts.ArtefactsName.Terre) &&
                    listArtefacts.Contains(Artefacts.ArtefactsName.Eau) &&
                    listArtefacts.Contains(Artefacts.ArtefactsName.Feu);
        }


    /**
     * @Description Une méthode pour tester l'état de jeu perdu
     */
    public bool Lose(){
        foreach(Player p in listPlayers) { // test si un joueur est noyé
            if(!p.getZone().isSafe())
                return true;
        }
        if(this.seaLevel >= 11)
            return true;
        int[] counterElmts = new int [4];
        for(int i=0; i<LARGEUR; i++) {
            for (int j = 0; j < HAUTEUR; j++) {
                if(!zones[i][j].isSafe() && zones[i][j].isHeliport()) // test si l'heliport est inondé
                        return true;

                // on ccompte le nombre d'artefact d'un même élement qu'on ne peut plus récuperer
                if(zones[i][j].getArtefacts()==Artefacts.ArtefactsName.Air && !zones[i][j].isSafe() )
                    counterElmts[0]+=1;
                else if(zones[i][j].getArtefacts()==Artefacts.ArtefactsName.Eau && !zones[i][j].isSafe() )
                    counterElmts[1]+=1;
                else if(zones[i][j].getArtefacts()==Artefacts.ArtefactsName.Feu && !zones[i][j].isSafe() )
                    counterElmts[2]+=1;
                else if(zones[i][j].getArtefacts()==Artefacts.ArtefactsName.Terre && !zones[i][j].isSafe() )
                    counterElmts[3]+=1;
            }
        }

        for(int i = 0; i<4; i++){
            if(counterElmts[i]>=2) // si un tous les artefcts récupérable d'un même élément sont noyés alors on perd
                return true;
        }

        return false;
    }

    public Zone[][] getGrille()
    {
        return this.zones;
    }

    public List<Player> GetListPlayers()
    {
        return this.listPlayers;
    }
    
    //Todo : A tester mais devrais melanger un Array
    public static void Shuffle<T>(IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public bool isMovable(Player player)
    {
        return getRoundOf().Equals(player) || typeof(Navigateur).IsInstanceOfType(getRoundOf());
    }


}
