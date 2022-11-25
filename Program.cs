// -------------------------------------------------- INITIALISATION VARIABLES
int valeurCaseVide = -1;

Console.Write($"Saisir le nombre de cartes par n-uplet : ");
int nbCartesParUplet = int.Parse(Console.ReadLine()!);
Console.Write($"Saisir le nombre de n-uplet(s) : ");
int nbUplets = int.Parse(Console.ReadLine()!);
int[,] tableauDesReponses = new int[nbCartesParUplet, nbUplets];
// genererNouvelleGrille(tableauDesReponses);
int[,] tableauJoueur = new int[nbCartesParUplet, nbUplets];
// remplirGrille2Dimensions(tableauJoueur, valeurCaseVide);
int dernierCoupJoue; // A initialiser après le 1er coup
int compteur = 0;

// -------------------------------------------------- SOUS-PROGRAMMES

void genererNouvelleGrille(int[,] grille)
{
    // On commence par reset la grille
    remplirGrille2Dimensions(grille, valeurCaseVide);

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
        } while (indexOfintInTab(dejaPlaces, valAPlacer) != -1);

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

int indexOfintInTab(int[] tab, int x)
{
    int i = 0;
    while (i < tab.Length && tab[i] != x) i++;
    if (i < tab.Length) return i; // Si on trouve l'élément on renvoie sa position
    return -1; // -1 sinon
}

void remplirGrille2Dimensions(int[,] grille, int valeur)
{
    for (int i = 0; i < grille.GetLength(0); i++)
        for (int j = 0; j < grille.GetLength(1); j++)
            grille[i, j] = valeur;
}

void jouerUnCoup(int ligne, int colonne)
{
    // A coder
}

void afficherGrille(int[,] grille)
{
    // A coder
}

bool aGagne()
{
    return false; // A coder
}

// -------------------------------------------------- TESTS
// remplirGrille
int[,] grille = { { 1, 2, 3 }, { 5, 5, 5 } };
remplirGrille2Dimensions(grille, 25);
string ch = "[";
for (int i = 0; i < grille.GetLength(0); i++)
{
    ch += '[';
    for (int j = 0; j < grille.GetLength(1) - 1; j++)
    {
        ch += grille[i, j] + ", ";
    }
    ch += grille[i, grille.GetLength(1) - 1] + "]";
    ch += (i < grille.GetLength(0) - 1) ? ",\n" : "]";
}
Console.WriteLine(ch);