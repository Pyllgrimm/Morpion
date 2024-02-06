using System.Runtime.ExceptionServices;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] joueurs = ["Joueur 1", "Joueur 2"];
        char[] symboles = ['X', 'O']; 
    
        bool rejouer = false;
        
        while (!rejouer)
        {
            char[,] grille = 
            {
                {'┌','─','┬','─','┬','─','┐' },
                {'│','.','│','.','│','.','│' },
                {'├','─','┼','─','┼','─','┤' },
                {'│','.','│','.','│','.','│' },
                {'├','─','┼','─','┼','─','┤' },
                {'│','.','│','.','│','.','│' },
                {'└','─','┴','─','┴','─','┘' },
            };

            int nombreDeTours = 0;
            bool jeu = true;

            while (jeu) {
                int[] caseChoisie = [0, 1];

                for (int i = 0; i < joueurs.Length; i++)
                {
                    DessinerGrille(grille);

                    bool verification = false;
                    while (!verification)
                    {
                        Console.WriteLine($"{joueurs[i]} choisissez la position de votre {symboles[i]} de 1 à 9 : ");
                        string choixJoueur = Console.ReadLine();

                        int[] choixCase = CaseValide(choixJoueur, caseChoisie);

                        if (grille[choixCase[0], choixCase[1]] != '.')
                            Console.WriteLine("Case invalide, choisissez en une autre !");

                        else
                        {
                            grille[choixCase[0], choixCase[1]] = symboles[i];
                            nombreDeTours++;

                            verification = true;
                        }
                    }
                    if (nombreDeTours == 9)
                    {
                        Console.Clear();

                        Console.WriteLine("Il n'y a pas de vainqueur !");
                        Console.WriteLine("Voulez-vous Rejouez ? o/n ");

                        string entreeUtilisateur = Console.ReadLine();

                        rejouer = Rejouez(grille, entreeUtilisateur);
                        jeu = false;
                        break;
                    }
                    else if (estComplete(grille))
                    {
                        Console.Clear();

                        DessinerGrille(grille);

                        Console.WriteLine($"Le vainqueur est {joueurs[i]} !");
                        Console.WriteLine("==============");

                        Console.WriteLine("Voulez-vous Rejouez ? o/n ");

                        string entreeUtilisateur = Console.ReadLine();

                        rejouer = Rejouez(grille, entreeUtilisateur);
                        jeu = false;
                        break;
                    }
                    Console.Clear();

                }
            }
            Console.Clear();
        }
    }
    public static bool estComplete(char[,] grille)
    {
        for (int i = 0; i < grille.GetLength(0); i++)
        {
            for (int j = 0; j < grille.GetLength(1); j++)
            {
                    if (grille[1, 1] == 'X' && grille[1, 3] == 'X' && grille[1, 5] == 'X' || 
                        grille[1, 1] == 'O' && grille[1, 3] == 'O' && grille[1, 5] == 'O')
                        return true;

                    if (grille[1, 1] == 'X' && grille[3, 1] == 'X' && grille[5, 1] == 'X' || 
                        grille[1, 1] == 'O' && grille[3, 1] == 'O' && grille[5, 1] == 'O')
                        return true;

                    if (grille[1, 5] == 'X' && grille[3, 5] == 'X' && grille[5, 5] == 'X' || 
                        grille[1, 5] == 'O' && grille[3, 5] == 'O' && grille[5, 5] == 'O')
                        return true;

                    if (grille[5, 1] == 'X' && grille[5, 3] == 'X' && grille[5, 5] == 'X' || 
                        grille[5, 1] == 'O' && grille[5, 3] == 'O' && grille[5, 5] == 'O')
                        return true;

                    if (grille[1, 3] == 'X' && grille[3, 3] == 'X' && grille[5, 3] == 'X' ||
                        grille[1, 3] == 'O' && grille[3, 3] == 'O' && grille[5, 3] == 'O')
                        return true;

                    if (grille[3, 1] == 'X' && grille[3, 3] == 'X' && grille[3, 5] == 'X' ||
                        grille[3, 1] == 'O' && grille[3, 3] == 'O' && grille[3, 5] == 'O')
                        return true;

                    if (grille[1, 1] == 'X' && grille[3, 3] == 'X' && grille[5, 5] == 'X' ||
                        grille[1, 1] == 'O' && grille[3, 3] == 'O' && grille[5, 5] == 'O')
                        return true;

                    if (grille[1, 5] == 'X' && grille[3, 3] == 'X' && grille[5, 1] == 'X' ||
                        grille[1, 5] == 'O' && grille[3, 3] == 'O' && grille[5, 1] == 'O')
                        return true;
            } 
        }
        return false;
    }
    
    public static int[] CaseValide(string choixJoueur, int[] caseChoisie)
    {
        

        switch (choixJoueur)
        {
            case "1":
                caseChoisie[0] = 5;
                caseChoisie[1] = 1;
                break;
            case "2":
                caseChoisie[0] = 5;
                caseChoisie[1] = 3;
                break;
            case "3":
                caseChoisie[0] = 5;
                caseChoisie[1] = 5;
                break;
            case "4":
                caseChoisie[0] = 3;
                caseChoisie[1] = 1;
                break;
            case "5":
                caseChoisie[0] = 3;
                caseChoisie[1] = 3;
                break;
            case "6":
                caseChoisie[0] = 3;
                caseChoisie[1] = 5; 
                break;
            case "7":
                caseChoisie[0] = 1;
                caseChoisie[1] = 1;
                break;
            case "8":
                caseChoisie[0] = 1;
                caseChoisie[1] = 3;
                break;
            case "9":
                caseChoisie[0] = 1;
                caseChoisie[1] = 5;
                break;
            default:
                break;
        }
        return caseChoisie;
    }

    public static void DessinerGrille(char[,] grille)
    {
        for (int i = 0; i < grille.GetLength(0); i++)
        {
            for (int j = 0; j < grille.GetLength(1); j++)
            {
                Console.Write(grille[i, j]);
            }
            Console.WriteLine();
        }
    }

    public static bool Rejouez(char[,] grille, string entree)
    {
        if (entree != "o")
            return true;
        else
            return false;    
    }
}