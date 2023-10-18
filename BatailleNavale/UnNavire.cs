using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurDeBatailleNavale
{
    public class UnNavire
    {
        public string Nom { get; }
        public EtatDeNavire Etat { get; private set; }
        public OrientationNavire Orientation { get; }
        public UneSectionDeNavire[] Sections { get; }

        public UnNavire(string nom, byte nombreDeSections)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArgumentNullException(nameof(nom), "Le nom du navire ne peut pas être null ou vide.");
            }

            if (nombreDeSections < 2 || nombreDeSections > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(nombreDeSections), "Le nombre de sections doit être entre 2 et 5.");
            }

            Nom = nom;
            Etat = EtatDeNavire.Intact;
            Sections = new UneSectionDeNavire[nombreDeSections];
            Orientation = OrientationNavire.Horizontal; // Par défaut, l'orientation est horizontale

            for (int i = 0; i < nombreDeSections; i++)
            {
                Sections[i] = new UneSectionDeNavire();
            }
        }
    }
}
