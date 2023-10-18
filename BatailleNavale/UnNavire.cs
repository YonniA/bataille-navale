using BatailleNavale;
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

        public void Réparer()
        {
            foreach (UneSectionDeNavire section in Sections)
            {
                section.Etat = EtatDeSectionDeNavire.Intact;
            }
        }

        public void Positionner(CoordonnéesDeBatailleNavale coordonnées, OrientationNavire orientation)
        {
            if (coordonnées.Colonne < 'A' || coordonnées.Colonne > 'J' || coordonnées.Ligne < 1 || coordonnées.Ligne > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(coordonnées), "Coordonnées de positionnement non valides.");
            }
            Sections[0].Position = coordonnées;
            for (int i = 1; i < Sections.Length; i++)
            {
                if (orientation == OrientationNavire.Horizontal)
                {
                    Sections[i].Position = new CoordonnéesDeBatailleNavale((char)(coordonnées.Colonne + i), coordonnées.Ligne);
                }
                else
                {
                    Sections[i].Position = new CoordonnéesDeBatailleNavale(coordonnées.Colonne, (byte)(coordonnées.Ligne + i));
                }
            }
        }
    }
}
