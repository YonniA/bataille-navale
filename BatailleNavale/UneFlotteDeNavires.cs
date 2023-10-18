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
    }
}
