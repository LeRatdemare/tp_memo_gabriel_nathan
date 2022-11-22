Console.Write($"Saisir le nombre de cartes par n-uplet : ");
int nbCartesParUplet = int.Parse(Console.ReadLine()!);
Console.Write($"Saisir le nombre de n-uplet(s) : ");
int nbUplets = int.Parse(Console.ReadLine()!);
int[,] tableauDesReponses = new int[nbCartesParUplet, nbUplets]; // A générer
genererNouvelleGrille(tableauDesReponses);
int[,] tableauJoueur = new int[nbCartesParUplet, nbUplets]; // Mettre des -1 partout
char dernierCoupJoue; // A initialiser après le 1er coup
int compteur = 0;

void genererNouvelleGrille(int[,] grille)
{
    // On commence par mettre des -1 de partout
    remplirGrille2Dimensions(grille, -1);

    /* Ensuite on va choisir un caractère au hasard sur une plage donnée
    dont on va placer tous les éléments du n-uplet sur la grille. */
    char[] dejaPlaces = new char[nbUplets];
    Random gen = new Random();

    for (int i = 0; i < nbUplets; i++)
    {
        // On va générer un caractère aléatoire tant qu'on en a un qui est dans dejaPlaces
        char c;
        do
        {
            c = (char)('a' + gen.Next(0, nbUplets));
        } while (indexOfCharInTab(dejaPlaces, c) != -1);

        // Ensuite on place toutes les cartes -c- dans la grille
        // A coder
    }
}

int indexOfCharInTab(char[] tab, char c)
{
    int i = 0;
    while (i < tab.Length && tab[i] != c) i++;
    if (i < tab.Length) return i; // Si on trouve l'élément on renvoie sa position
    return -1; // -1 sinon
}

void remplirGrille2Dimensions(int[,] grille, int valeur)
{
    // A coder
}

void jouerUnCoup(int ligne, int colonne)
{
    // A coder
}

void afficherGrille()
{
    // A coder
}

bool aGagne()
{
    return false; // A coder
}