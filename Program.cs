// -------------------------------------------------- INITIALISATION VARIABLES
int valeurCaseVide = -1;

Console.Write($"Saisir le nombre de cartes par n-uplet : ");
int nbCartesParUplet = int.Parse(Console.ReadLine()!);
Console.Write($"Saisir le nombre de n-uplet(s) : ");
int nbUplets = int.Parse(Console.ReadLine()!);
int[,] tableauDesReponses = new int[nbCartesParUplet, nbUplets];
GenererNouvelleGrille(tableauDesReponses);
int[,] tableauJoueur = new int[nbCartesParUplet, nbUplets];
RemplirGrille2Dimensions(tableauJoueur, valeurCaseVide);
int dernierCoupJoue = -1; // On initialise à -1 pour traiter le 1er coup comme si on cassait la série en cours
int compteur = 0;

// -------------------------------------------------- SOUS-PROGRAMMES

/* La grille doit obligatoirement avoir nbUplets*nbCartesParUplet
    cases, quelque soit ses dimensions.*/
void GenererNouvelleGrille(int[,] grille)
{
    // On commence par reset la grille
    RemplirGrille2Dimensions(grille, valeurCaseVide);
    Random gen = new Random();

    for (int i = 0; i < nbUplets; i++)
    {
        // On place toutes les cartes i dans la grille
        int nbCartesPlaceesDuUplet = 0;
        int position;
        while (nbCartesPlaceesDuUplet < nbCartesParUplet)
        {
            // On commence par déterminer les coordonnées de la case où placer la carte
            position = gen.Next(0, nbCartesParUplet * nbUplets);
            int ligne = position / grille.GetLength(1);
            int colonne = position % grille.GetLength(1);
            // Après avoir on parcours la grille depuis la case générée jusqu'à tomber sur une case vide
            while (grille[ligne, colonne] != -1)
            {
                colonne = ++colonne % grille.GetLength(1);
                ligne = (ligne + (colonne == 0 ? 1 : 0)) % grille.GetLength(0);
            }
            // A ce moment là on place une carte et on incrémente le compteur
            grille[ligne, colonne] = i;
            nbCartesPlaceesDuUplet++;
        }
    }
}

int IndexOfintInTab(int[] tab, int x)
{
    int i = 0;
    while (i < tab.Length && tab[i] != x) i++;
    if (i < tab.Length) return i; // Si on trouve l'élément on renvoie sa position
    return -1; // -1 sinon
}

void RemplirGrille2Dimensions(int[,] grille, int valeur)
{
    for (int i = 0; i < grille.GetLength(0); i++)
        for (int j = 0; j < grille.GetLength(1); j++)
            grille[i, j] = valeur;
}

bool JouerUnCoup(int ligne, int colonne)
{
    // On vérifie que les coordonnées sont dans la grille et que la case est libre
    if (!CoupValide(ligne, colonne))
    {
        Console.WriteLine($"Les coordonnées saisies ne sont pas valides (hors de la grille ou carte déjà retournée)...");
        return false;
    }

    // Si la carte retournée est la même que -dernierCoupJoue- on incrémente le compteur
    if (tableauDesReponses[ligne, colonne] == dernierCoupJoue)
        compteur++;

    // Sinon si on casse la série actuelle
    else
    {
        // Si on n'avait pas encore trouvé toutes les cartes du n-uplet
        if (compteur < nbCartesParUplet)
        {
            // On cache toutes les -dernierCoupJoue- de la grille
            for (int i = 0; i < tableauJoueur.GetLength(0); i++)
                for (int j = 0; j < tableauJoueur.GetLength(1); j++)
                    if (tableauJoueur[i, j] == dernierCoupJoue)
                        tableauJoueur[i, j] = valeurCaseVide;
        }
        compteur = 1;
    }

    // Quoi qu'il arrive on rend visible la carte sur -tableauJoueur-
    tableauJoueur[ligne, colonne] = tableauDesReponses[ligne, colonne];
    // On n'oublie pas non plus de mettre à jour le dernierCoup
    dernierCoupJoue = tableauJoueur[ligne, colonne];
    return true;
}

bool CoupValide(int ligne, int colonne)
{
    return ligne >= 0 && ligne < tableauJoueur.GetLength(0) &&
    colonne >= 0 && colonne < tableauJoueur.GetLength(1) &&
    tableauJoueur[ligne, colonne] == -1;
}

void AfficherGrille(int[,] grille)
{
    Console.Write("  ");
    for (int colonne = 0; colonne < grille.GetLength(1); colonne++)
        Console.Write((char)(colonne + 'A')); // Affichage du nom des colonnes pour aider le joueur

    Console.WriteLine();

    for (int ligne = 0; ligne < grille.GetLength(0); ligne++)
    {

        Console.Write($"{ligne} "); // Affichage du nom de la ligne pour aider le joueur

        for (int colonne = 0; colonne < grille.GetLength(1); colonne++)
        {
            if (grille[ligne, colonne] == valeurCaseVide)
                Console.Write("*"); // On affiche une astérisque lorsque l'item n'a pas encore été trouvé

            else
                Console.Write((char)(grille[ligne, colonne] + 'a')); // On affiche l'item quand il a été trouvé
        }

        Console.WriteLine(); // Retour à la ligne
    }


}


bool AGagne(int[,] grille)
{
    for (int ligne = 0; ligne < grille.GetLength(0); ligne++)
    {
        for (int colonne = 0; colonne < grille.GetLength(1); colonne++)
        {
            if (grille[ligne, colonne] == valeurCaseVide) // Le joueur n'a pas gagné s'il reste un ou plusieurs items n'ont pas été trouvés
                return false;
        }
    }
    return true; // Tous les items ont été trouvés. Le joueur a donc gagné.

}

void LancerLaPartie()
{

}

// -------------------------------------------------- TESTS
// RemplirGrille & afficherGrille
int[,] grille = { { 1, -1, 3 }, { -1, 5, -1 } };
// RemplirGrille2Dimensions(grille, 25);
// AfficherGrille(grille);

// AGagne

// grille[0, 1] = 1;
// grille[1, 0] = 1;
// grille[1, 2] = 1;
// if (AGagne(grille) == true)
//     Console.WriteLine("Félicitation ! Vous avez gagné.");


// LancerLaPartie

// GenererNouvelleGrille
/* Problèmes à résoudre : Les caractères de même valeur sont trop rapprochés.*/
// GenererNouvelleGrille(tableauDesReponses);
// AfficherGrille(tableauDesReponses);


// JouerUnCoup ---------
// Console.WriteLine($"Solution :");
// AfficherGrille(tableauDesReponses);
// Console.WriteLine($"Tableau du joueur AVANT le coup");
// AfficherGrille(tableauJoueur);
// Console.WriteLine($"Tableau du joueur APRES le coup");
// JouerUnCoup(tableauJoueur.GetLength(0) - 1, tableauJoueur.GetLength(1) - 1);
// AfficherGrille(tableauJoueur);
// JouerUnCoup(0, 0);
// AfficherGrille(tableauJoueur);
// JouerUnCoup(0, 1);
// AfficherGrille(tableauJoueur);
// JouerUnCoup(0, 2);
// AfficherGrille(tableauJoueur);
// JouerUnCoup(0, 3);
// AfficherGrille(tableauJoueur);
// JouerUnCoup(0, 4);
// AfficherGrille(tableauJoueur);

