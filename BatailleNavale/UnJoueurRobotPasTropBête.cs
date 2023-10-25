using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UnJoueurRobotPasTropBête : UnJoueurAvecUneFlotteDeNavireEtUneCarteDeTirs
    {
        private readonly Random _random;

        public UnJoueurRobotPasTropBête(string pseudo) : base(pseudo)
        {
            _random = new Random();
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
            CoordonnéesDeBatailleNavale coordonnées;
            do
            {
                char colonne = (char)(_random.Next(10) + 'A');
                byte ligne = (byte)(_random.Next(10) + 1);
                coordonnées = new CoordonnéesDeBatailleNavale(colonne, ligne);
            } while (CarteDesTirs.VérifierEmplacement(coordonnées) != RésultatDeTir.Inconnu);
            return coordonnées;
        }
    }
}
