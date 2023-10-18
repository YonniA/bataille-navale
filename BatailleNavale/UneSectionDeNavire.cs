using BatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UneSectionDeNavire
    {
        public EtatDeSectionDeNavire Etat { get; set; }
        public CoordonnéesDeBatailleNavale Position { get; set; }

        public UneSectionDeNavire()
        {
            Etat = EtatDeSectionDeNavire.Intact;
            Position = new CoordonnéesDeBatailleNavale('A', 1); // Position par défaut à A1
        }
    }
}

