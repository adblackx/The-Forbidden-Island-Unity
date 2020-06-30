# The-Forbidden-Island-Unity

Ce projet à pour but de réaliser une version mobile du jeux de plateau L'Ile Interdite en utilisant unity.

## Comment ça se joue :

[Règles du jeu](https://github.com/Guildart/theforbiddenisland/blob/master/regle.pdf "Règles de L'ile Interdite")


    - Le joueur peut se deplacer (ou deplacer les autres dans le cas du navigateur) en faisant un
    Drag and Drop, il suffit donc de faire glisser les pions.
    
    - Un joueur peut donner une carte à un autre joueur pendant sont tour (quand les conditions sont
    réunit) en faisant un Drag and Drop de sa carte vers la main de son coéquipier.
    
    - De même le joueurs peut utiliser une carte spéciale (sans coût d'action) en glissant sa carte
    vers la zone de l'île où il veut se rendre.
    
    - Nous avons implémenté les différents rôles du jeux, le joueur devra au lancement du jeux
    sélectionner 2 à 4 rôles (selon le nombre de joueurs voulut) pour lancer une partie.
    
    - Nous avons implementer les paquets de cartes ainsi que la fonctionnalitée montée des eaux, quand une
    carte montée des eaux est tirée ont mélange la defausse des cartes innondation au tas de carte
    innondation (Attention des zones vont commencer à sombrer!!!). Selon la zone ou est le curseur,
    sur la règle montée des eaux (panneaux du bas dans la fênetre), 2 à 5 cartes inondation seront tirées.
    
    - De même les Cartes tresors sont implémentés, quand le tas est vide on mélange la défausse qui
    devient la nouvelle main.
    
    - Pour coller au mieux aux règles officielles, un joueur ne peut avoir plus de 5 cartes en mains,
    aussi à chaque debut de tours si un joueurs à trop cartes une fenetre pop up s'ouvrira 
    et le joueur sera obligé de défausser un nombre minimale de carte.
    
    - Pour récupérer un Tresor/Artefacts le joueurs devra se trouver sur la case de l'artefacts voulu,
    avoir en sa possession 4 cartes tresors et cliquer sur le bouton "Take Tresor"
    
    - Pour finir son tours le jouer devra cliquer sur Next Round, il
    tirera alors 2 cartes tresors dans la pioche et ce sera au joueur suivant
    
    - Le joueur dont c'est le tour verra le fond derrière sa main (panneau de droite) devenir vert,
    de plus il est indiqué sous les boutons ("Next Round" et "Take Tresor") le role du joeur dont c'est
    le tour et le nombre d'action qu'il lui reste
    
    - Un joueur peut arrêter sont tour et passer au prochain joueur quand il le veut en cliquant
    sur "Next Round", aucune obligation de réaliser des actions.
    
    - Sur la grille sont représenteés par des logo eau, vent, air, feu les zones contenant des artefacts

    - Quand un joueur prend un artefacts celui ci disparait de la zone où elle se trouvait et
    l'artefacts correspondant sur le panneau en bas de l'île se colorisera
    
    - Pour gagner après avoir obtenu tous les artefacts, tous les joueurs devront être sur la case
    Heliport (la case de l'île avec un sybole H) et utiliser une carte Helicopter pour décoller de
    l'île
    
    - Les joueurs perdent si toutes les tuiles contenant un artefacts sombres avant qu'il l'ai 
    récupéré, si un joueur se noie, si l'héliport sombre ou si le niveau de l'eau atteint la tête
    de mort.
