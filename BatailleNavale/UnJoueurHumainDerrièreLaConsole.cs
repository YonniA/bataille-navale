using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UnJoueurHumainDerrièreLaConsole : IContratDuJoueurDeBatailleNavale
    {
        public string Pseudo { get; }

        public UnJoueurHumainDerrièreLaConsole()
        {
            Console.Write("Veuillez entrer votre pseudo : ");
            Pseudo = Console.ReadLine();
        }

        public void PréparerLaBataille()
        {
            // ne fait rien dans cette version
        }

        public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            Console.Write($"{Pseudo}, veuillez entrer les coordonnées de tir (colonne de 'A' à 'J' suivi de la ligne de 1 à 10) : ");
            string input = Console.ReadLine();
            char colonne = input[0];
            byte ligne = byte.Parse(input.Substring(1));

            return new CoordonnéesDeBatailleNavale(colonne, ligne);
        }

        public RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées)
        {
            Console.Write($"{Pseudo}, veuillez entrer le résultat du tir pour les coordonnées {coordonnées.Colonne}{coordonnées.Ligne} (Inconnu, Raté, Touché, TouchéCoulé) : ");
            string résultatStr = Console.ReadLine();

            if (Enum.TryParse<RésultatDeTir>(résultatStr, out RésultatDeTir résultat))
            {
                return résultat;
            }
            else
            {
                Console.WriteLine("Résultat de tir non valide. Le tir est considéré comme 'Inconnu'.");
                return RésultatDeTir.Inconnu;
            }
        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées, RésultatDeTir résultat)
        {
            Console.WriteLine($"Résultat du tir pour les coordonnées {coordonnées.Colonne}{coordonnées.Ligne} : {résultat}");
        }
    }
}
