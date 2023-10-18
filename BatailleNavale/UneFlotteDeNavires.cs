using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UneFlotteDeNavires
    {
        public UnNavire[] Navires { get; }

        public UneFlotteDeNavires()
        {
            Navires = new UnNavire[]
            {
                new UnNavire("porte avion", 5),
                new UnNavire("croiseur", 4),
                new UnNavire("contre torpilleur", 3),
                new UnNavire("sous-marin", 3),
                new UnNavire("torpilleur", 2)
            };
        }

        public void RéparerTousLesNavires()
        {
            foreach (UnNavire navire in Navires)
            {
                navire.Réparer();
            }
        }

        public RésultatDeTir VérifierLeRésultatDuTir(CoordonnéesDeBatailleNavale caseCible)
        {
            foreach (UnNavire navire in Navires)
            {
                RésultatDeTir résultat = navire.VérifierLeRésultatDuTir(caseCible);
                if (résultat == RésultatDeTir.TouchéCoulé)
                {
                    bool tousLesAutresNaviresCoulés = true;
                    foreach (UnNavire autreNavire in Navires)
                    {
                        if (autreNavire != navire && autreNavire.Etat != EtatDeNavire.Coulé)
                        {
                            tousLesAutresNaviresCoulés = false;
                            break;
                        }
                    }
                    if (tousLesAutresNaviresCoulés)
                    {
                        return RésultatDeTir.TouchéCouléFinal;
                    }
                }
                if (résultat != RésultatDeTir.Raté)
                {
                    return résultat;
                }
            }
            return RésultatDeTir.Raté;
        }

    }
}
