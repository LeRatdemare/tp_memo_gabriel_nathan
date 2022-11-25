// -------------------------------------------------- INITIALISATION VARIABLES
int valeurCaseVide = -1;

Console.Write($"Saisir le nombre de cartes par n-uplet : ");
int nbCartesParUplet = int.Parse(Console.ReadLine()!);
Console.Write($"Saisir le nombre de n-uplet(s) : ");
int nbUplets = int.Parse(Console.ReadLine()!);
int[,] tableauDesReponses = new int[nbCartesParUplet, nbUplets];
// GenererNouvelleGrille(tableauDesReponses);
int[,] tableauJoueur = new int[nbCartesParUplet, nbUplets];
// RemplirGrille2Dimensions(tableauJoueur, valeurCaseVide);
int dernierCoupJoue; // A initialiser après le 1er coup
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
            position = gen.Next(0, nbCartesParUplet * nbCartesPlaceesDuUplet);
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

void JouerUnCoup(int ligne, int colonne)
{
    // A coder
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


bool AGagne()
{
    return false; // A coder
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

// LancerLaPartie

// GenererNouvelleGrille
GenererNouvelleGrille(tableauDesReponses);
AfficherGrille(tableauDesReponses);


// JouerUnCoup

