using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UnJoueurHumain : UnJoueurAvecUneFlotteDeNavireEtUneCarteDeTirs
    {
        public UnJoueurHumain(string pseudo) : base(pseudo)
        {
        }

        public override void PréparerLaBataille()
        {
            base.PréparerLaBataille();
            foreach (var navire in Flotte.Navires)
            {
                navire.Positionner(new CoordonnéesDeBatailleNavale('A', 1), OrientationNavire.Horizontal);
            }
        }

        public override CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            CarteDesTirs.DessinerDansLaConsole();

            Console.WriteLine($"Joueur {Pseudo}, veuillez entrer les coordonnées de tir (colonne de 'A' à 'J' suivi de la ligne de 1 à 10, ex: A5): ");
            string saisie = Console.ReadLine();
            while (!EstSaisieValide(saisie))
            {
                Console.WriteLine("Coordonnées invalides. Veuillez réessayer:");
                saisie = Console.ReadLine();
            }

            char colonne = char.ToUpper(saisie[0]);
            byte ligne = byte.Parse(saisie.Substring(1));

            return new CoordonnéesDeBatailleNavale(colonne, ligne);
        }

        private bool EstSaisieValide(string saisie)
        {
            if (saisie.Length < 2)
            {
                return false;
            }

            char colonne = char.ToUpper(saisie[0]);
            if (colonne < 'A' || colonne > 'J')
            {
                return false;
            }

            if (!byte.TryParse(saisie.Substring(1), out byte ligne) || ligne < 1 || ligne > 10)
            {
                return false;
            }

            return true;
        }
    }
}
