using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UnJoueurRobotPasTrèsIntelligent : UnJoueurAvecUneFlotteDeNavires
    {
        public UnJoueurRobotPasTrèsIntelligent(string pseudo) : base(pseudo)
        {
        }

        public override void PréparerLaBataille()
        {
            base.PréparerLaBataille(); 
            byte ligne = 1;
            foreach (UnNavire navire in Flotte.Navires)
            {
                navire.Positionner(new CoordonnéesDeBatailleNavale('A', ligne++),
               OrientationNavire.Horizontal);
            }
        }

        public override CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            Random random = new Random();
            char colonne = (char)('A' + random.Next(10));
            byte ligne = (byte)(random.Next(10) + 1); 
            CoordonnéesDeBatailleNavale coordonnées = new CoordonnéesDeBatailleNavale(colonne, ligne);

            Console.WriteLine($"Le joueur {Pseudo} attaque en {coordonnées.Colonne}{coordonnées.Ligne}.");
            return coordonnées;
        }

        public override void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées, RésultatDeTir résultat)
        {
            // Ne fait rien pour l'instant
        }

        public override RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale caseCible)
        {
            RésultatDeTir résultat = Flotte.VérifierLeRésultatDuTir(caseCible);
            Console.WriteLine($"Résultat du tir en {caseCible.Colonne}{caseCible.Ligne}: {résultat}");
            return résultat;
        }
    }
}
