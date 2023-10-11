namespace BatailleNavale
{
    public enum RésultatDeTir
        {
            Inconnu,
            Raté,
            Touché,
            TouchéCoulé,
            TouchéCouléFinal
        }

    public class CoordonnéesDeBatailleNavale
    {
        public char Colonne { get; }
        public byte Ligne { get; }

        private CoordonnéesDeBatailleNavale() { }

        public CoordonnéesDeBatailleNavale(char colonne, byte ligne)
        {
            if (colonne < 'A' || colonne > 'J' || ligne < 1 || ligne > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            Colonne = colonne;
            Ligne = ligne;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CoordonnéesDeBatailleNavale otherCoord = (CoordonnéesDeBatailleNavale)obj;
            return Colonne == otherCoord.Colonne && Ligne == otherCoord.Ligne;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Colonne, Ligne);
        }
    }

    public interface IContratDuJoueurDeBatailleNavale
    {
        string Pseudo { get; }
        void PréparerLaBataille();
        CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();
        RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées);
        void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnées, RésultatDeTir résultat);
    }

}
