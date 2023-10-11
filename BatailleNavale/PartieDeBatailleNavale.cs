using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class PartieDeBatailleNavale
    {
        public IContratDuJoueurDeBatailleNavale Attaquant { get; private set; }
        public IContratDuJoueurDeBatailleNavale Défenseur { get; private set; }

        public PartieDeBatailleNavale(IContratDuJoueurDeBatailleNavale attaquant, IContratDuJoueurDeBatailleNavale défenseur)
        {
            if (attaquant == null || défenseur == null)
            {
                throw new ArgumentNullException("Les joueurs ne peuvent pas être null.");
            }

            Attaquant = attaquant;
            Défenseur = défenseur;
        }

        public void ChoisirLesRôlesDeDépartDesJoueurs()
        {
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                // Attaquant commence
                Console.WriteLine($"{Attaquant.Pseudo} est l'attaquant. {Défenseur.Pseudo} est le défenseur.");
            }
            else
            {
                // Défenseur commence
                Console.WriteLine($"{Défenseur.Pseudo} est l'attaquant. {Attaquant.Pseudo} est le défenseur.");
                IntervertirLesRôlesDesJoueurs();
            }
        }

        public void IntervertirLesRôlesDesJoueurs()
        {
            var temp = Attaquant;
            Attaquant = Défenseur;
            Défenseur = temp;
        }

        public void PréparerLaBataille()
        {
            Attaquant.PréparerLaBataille();
            Défenseur.PréparerLaBataille();
        }

        public void JouerLaPartie()
        {
            RésultatDeTir résultat = RésultatDeTir.Inconnu;

            while (résultat != RésultatDeTir.TouchéCouléFinal)
            {
                Console.WriteLine($"{Attaquant.Pseudo}, c'est votre tour.");
                CoordonnéesDeBatailleNavale coordonnéesDeTir = Attaquant.Attaquant_ChoisirLesCoordonnéesDeTir();
                résultat = Défenseur.Défenseur_FournirLeRésultatDuTir(coordonnéesDeTir);
                Attaquant.Attaquant_GérerLeRésultatDuTir(coordonnéesDeTir, résultat);

                if (résultat != RésultatDeTir.TouchéCouléFinal)
                {
                    IntervertirLesRôlesDesJoueurs();
                }
            }

            Console.WriteLine($"Félicitations, {Attaquant.Pseudo} ! Vous avez gagné la partie.");
        }
    }
}
