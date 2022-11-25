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

void GenererNouvelleGrille(int[,] grille)
{
    // On commence par reset la grille
    RemplirGrille2Dimensions(grille, valeurCaseVide);

    /* Ensuite on va choisir un caractère au hasard sur une plage donnée
    dont on va placer tous les éléments du n-uplet sur la grille. */
    int[] dejaPlaces = new int[nbUplets];
    Random gen = new Random();

    for (int i = 0; i < nbUplets; i++)
    {
        // On va générer un caractère aléatoire tant qu'on en a un qui est dans dejaPlaces
        int valAPlacer;
        do
        {
            valAPlacer = gen.Next(0, nbUplets);
        } while (IndexOfintInTab(dejaPlaces, valAPlacer) != -1);

        // Ensuite on place toutes les cartes -c- dans la grille
        int nbCartesDuUpletPlaces = 0;
        int position = 0;
        do
        {
            // S'il y a de la place dans la case actuelle, on a 20% de chances de mettre la valeur dedans
            if (tableauDesReponses[position / grille.GetLength(1), position % grille.GetLength(1)] == valeurCaseVide && gen.NextDouble() < 0.2)
            {
                tableauDesReponses[position / grille.GetLength(1), position % grille.GetLength(1)] = valAPlacer;
                nbCartesDuUpletPlaces++;
            }
            position = (++position) % nbUplets * nbCartesParUplet; // On avance dans le tableau
        } while (nbCartesDuUpletPlaces < nbCartesParUplet);
        dejaPlaces[i] = valAPlacer;
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





