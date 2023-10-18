using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public abstract class UnJoueurAvecUneFlotteDeNavires : IContratDuJoueurDeBatailleNavale
    {
        public string Pseudo { get; }
        public UneFlotteDeNavires Flotte { get; }

        public UnJoueurAvecUneFlotteDeNavires(string pseudo)
        {
            if (string.IsNullOrWhiteSpace(pseudo))
            {
                throw new ArgumentNullException(nameof(pseudo), "Le pseudo ne peut pas être null ou vide.");
            }

            Pseudo = pseudo;
            Flotte = new UneFlotteDeNavires();
        }

        public virtual void PréparerLaBataille()
        {
        }

        public abstract CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();
        public abstract RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées);
        public abstract void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées, RésultatDeTir résultat);
    }
}
