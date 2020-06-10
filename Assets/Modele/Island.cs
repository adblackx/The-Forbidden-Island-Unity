using System;
using System.Collections;
using System.Collections.Generic;
using Tfi;
using System.Collections;

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
    private readonly List<TresorCard.TresorCardName> tasCarteTresor = new List<TresorCard.TresorCardName>();
    /*Liste de la défausse*/
    private List<TresorCard.TresorCardName> defausseCarteTresor = new List<TresorCard.TresorCardName>();
    /*Liste de la pioche Inondation*/
    private List<Zone> tasCarteInnondation = new List<Zone>();
    /*Liste de la défausse inondation*/
    private ArrayList defausseCarteInnondation = new ArrayList();
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
        //initTasCarteTresor();

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
       // Collections.shuffle(defausseCarteInnondation); //on melange avant
        //tasCarteInnondation.addAll(defausseCarteInnondation);
        //defausseCarteInnondation.clear();


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

    //Todo A implementer
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
}
