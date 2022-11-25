int valeurCaseVide = -1;

Console.Write($"Saisir le nombre de cartes par n-uplet : ");
int nbCartesParUplet = int.Parse(Console.ReadLine()!);
Console.Write($"Saisir le nombre de n-uplet(s) : ");
int nbUplets = int.Parse(Console.ReadLine()!);
int[,] tableauDesReponses = new int[nbCartesParUplet, nbUplets];
genererNouvelleGrille(tableauDesReponses);
int[,] tableauJoueur = new int[nbCartesParUplet, nbUplets];
remplirGrille2Dimensions(tableauJoueur, valeurCaseVide);
int dernierCoupJoue; // A initialiser après le 1er coup
int compteur = 0;

void genererNouvelleGrille(int[,] grille)
{
    // On commence par mettre des -1 de partout
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
        int nbPlaces = 0;
        int position = 0;
        do
        {
            // S'il y a de la place dans la case actuelle, on a 20% de chances de mettre la valeur dedans
            if (tableauDesReponses[position / nbUplets, position % nbUplets] == valeurCaseVide && gen.NextDouble() < 0.2)
            {
                tableauDesReponses[position / nbUplets, position % nbUplets] = valAPlacer;
                nbPlaces++;
            }
            position = (position++) % nbUplets * nbCartesParUplet; // On avance dans le tableau
        } while (nbPlaces < nbCartesParUplet);
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
    // A coder
}

void jouerUnCoup(int ligne, int colonne)
{
    // A coder
}

void afficherGrille()
{
    //cette variable sert de compteur pour savoir à quelle colonne on se situe lors de l'affichage.

    for (int LigneAffichage = 0; LigneAffichage < nbCartesParUplet; LigneAffichage++)
    {
        for (int ColonneAffichage = 0; ColonneAffichage < nbUplets; ColonneAffichage++)
        {
            if (tableauJoueur[LigneAffichage, ColonneAffichage] == valeurCaseVide)
                Console.Write("*"); //on affiche une astérisque lorsque l'item n'a pas encore été trouvé

            if (tableauJoueur[LigneAffichage, ColonneAffichage] != valeurCaseVide)
                Console.Write((char)(tableauDesReponses[LigneAffichage, ColonneAffichage] + 'a')); //on affiche l'item quand item a été trouvé
        }

        Console.WriteLine(" "); //retour à la ligne
        LigneAffichage++; //mise à jour du compteur de colonnes
    }

}


bool aGagne()
{
    return false; // A coder
}