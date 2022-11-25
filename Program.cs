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
    // A coder
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
    int LigneAffichage = 0;      //cette variable sert de compteur pour l'affichage des items de la grille pour une ligne.
    int ColonneAffichage = 0;    //cette variable sert de compteur pour savoir à quelle colonne on se situe lors de l'affichage.
    while (LigneAffichage < nbUplets)
    {
        if (tableauJoueur[LigneAffichage,ColonneAffichage] == -1)
        {

        }
    }



}

bool aGagne()
{
    return false; // A coder
}