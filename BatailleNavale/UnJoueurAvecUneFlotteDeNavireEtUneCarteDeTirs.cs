using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public abstract class UnJoueurAvecUneFlotteDeNavireEtUneCarteDeTirs : UnJoueurAvecUneFlotteDeNavires
    {
        public CarteDesTirs CarteDesTirs { get; }

        public UnJoueurAvecUneFlotteDeNavireEtUneCarteDeTirs(string pseudo) : base(pseudo)
        {
            CarteDesTirs = new CarteDesTirs();
        }

        public override void PréparerLaBataille()
        {
            base.PréparerLaBataille();
            CarteDesTirs.MiseAZéro();
        }

        public override RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale caseCible)
        {
            return Flotte.VérifierLeRésultatDuTir(caseCible);
        }

        public override void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées, RésultatDeTir résultat)
        {
            CarteDesTirs.MarquerEmplacement(coordonnées, résultat);
            if (résultat == RésultatDeTir.TouchéCouléFinal)
            {
                CarteDesTirs.DessinerDansLaConsole();
            }
        }
    }
}
