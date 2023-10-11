using BatailleNavale;
using MoteurDeBatailleNavale;
using System.Reflection;

namespace TestDuMoteurDeBatailleNavale
{
    [TestClass]
    public class Test_Phase_1_Partie
    {
        [TestMethod]
        public void Phase1_1_CoordonnéesDeBatailleNavale()
        {
            // vérification du constructeur par défaut non public
            Type t = typeof(CoordonnéesDeBatailleNavale);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans paramètre
                if (constructeur.GetParameters().Length == 0)
                {
                    // vérification de visibilité
                    Assert.IsFalse(constructeur.IsPublic, "Le constructeur par défaut ne doit pas être public.");
                }
            }

            // vérification que les paramètres hors plage valide produisent une exception IndexOutOfRangeException
            bool ThrowException = false;
            try
            {
                ThrowException = false;
                for (char c = char.MinValue; c < 'A'; c++)
                {
                    CoordonnéesDeBatailleNavale coordonnéeInvalide = new
                    CoordonnéesDeBatailleNavale(c, 1);
                }
                for (char c = (char)('J' + 1); c < char.MaxValue; c++)
                {
                    CoordonnéesDeBatailleNavale coordonnéeInvalide = new
                    CoordonnéesDeBatailleNavale(c, 1);
                }
                CoordonnéesDeBatailleNavale coordonnéeInvalide2 = new
                CoordonnéesDeBatailleNavale('A', 0);
                for (byte l = 11; l < byte.MaxValue; l++)
                {
                    CoordonnéesDeBatailleNavale coordonnéeInvalide = new
                    CoordonnéesDeBatailleNavale('A', l);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de CoordonnéesDeBatailleNavale ne doit accepter que des colonnes de 'A' à 'J' et des lignes de 1 à 10");

            // vérification que les paramètres dans la plage valide ne produisent pas d'exception
            try
            {
                ThrowException = false;
                for (char c = 'A'; c <= 'J'; c++)
                {
                    for (byte l = 1; l <= 10; l++)
                    {
                        CoordonnéesDeBatailleNavale coordonnéeInvalide = new
                        CoordonnéesDeBatailleNavale(c, l);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsFalse(ThrowException, "La construction de CoordonnéesDeBatailleNavale doit accepter des colonnes entre 'A' et 'J' et des lignes entre 1 et 10");

            // vérification de la méthode Equals
            try
            {
                CoordonnéesDeBatailleNavale uneInstance = new
                CoordonnéesDeBatailleNavale('C', 5);
                uneInstance.Equals(null);
                uneInstance.Equals(new object());
                uneInstance.Equals(uneInstance);
            }
            catch
            {
                Assert.Fail("Le test d'égalité ne doit pas provoquer d'exception");
            }
            Assert.IsTrue(new CoordonnéesDeBatailleNavale('C', 5).Equals(new CoordonnéesDeBatailleNavale('C', 5)), "L'égalité C5 avec C5 doit être vraie");
            Assert.IsFalse(new CoordonnéesDeBatailleNavale('A', 1).Equals(null), "L'égalité avec null doit être fausse");
            Assert.IsFalse(new CoordonnéesDeBatailleNavale('A', 1).Equals(new CoordonnéesDeBatailleNavale('A', 2)), "L'égalité A1 avec A2 doit être fausse");
            Assert.IsFalse(new CoordonnéesDeBatailleNavale('A', 1).Equals("A1"), "L'égalité entre deux types différents doit être fausse");
        }
        public class joueurTest : IContratDuJoueurDeBatailleNavale
        {
            public joueurTest(string pseudo)
            {
                Pseudo = pseudo;
            }
            public string Pseudo { get; private set; }
            public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
            {
                return new CoordonnéesDeBatailleNavale('A', 1);
            }
            public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale
           coordonnéesDuTir, RésultatDeTir résultatDuTir)
            {
            }
            public RésultatDeTir
           Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir)
            {
                return RésultatDeTir.TouchéCouléFinal;
            }
            public void PréparerLaBataille()
            {
            }
        }
        [TestMethod]
        public void Phase1_2_PartieDeBatailleNavale_Constructeur()
        {
            // vérification du constructeur public
            Type t = typeof(PartieDeBatailleNavale);
            ConstructorInfo constructeurPublique = t.GetConstructor(new Type[] {
            typeof(IContratDuJoueurDeBatailleNavale), typeof(IContratDuJoueurDeBatailleNavale) });
            Assert.IsNotNull(constructeurPublique, "PartieDeBatailleNavale doit avoir un constructeur public attendant en paramètre 2 instance de IContratDuJoueurDeBatailleNavale");
            bool ThrowException = false;
            try
            {
                PartieDeBatailleNavale p = new PartieDeBatailleNavale(null, null);
                p = new PartieDeBatailleNavale(null, new joueurTest("joueur test"));
                p = new PartieDeBatailleNavale(new joueurTest("joueur test"), null);
            }
            catch (ArgumentNullException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de PartieDeBatailleNavale ne doit pas accepter les paramètes null");
        }
        [TestMethod]
        public void Phase1_3_PartieDeBatailleNavale_ChoisirLesRôlesDeDépartDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
            joueur2);
            // partie.ChoisirLesRôlesDeDépartDesJoueurs();
            // IContratDuJoueurDeBatailleNavale attaquantDeDépart = partie.Attaquant;
            int joueur1Attaquant = 0;
            int joueur2Attaquant = 0;
            for (int x = 0; x < 1000; x++)
            {
                partie.ChoisirLesRôlesDeDépartDesJoueurs();
                Assert.IsNotNull(partie.Attaquant, "L'attaquant ne peut pas être null");

                Assert.IsNotNull(partie.Défenseur, "Le défenseur ne peut pas être null");
                if (partie.Attaquant == joueur1)
                {
                    joueur1Attaquant++;
                    Assert.AreEqual(partie.Défenseur, joueur2, "Incohérence entre joueur ataquant et défenseur");
                }
                else if (partie.Attaquant == joueur2)
                {
                    joueur2Attaquant++;
                    Assert.AreEqual(partie.Défenseur, joueur1, "Incohérence entre joueur ataquant et défenseur");
                }
                else
                {
                    Assert.Fail("Incohérence entre joueur ataquant et défenseur");
                }
            }
            if (Math.Abs(joueur1Attaquant - joueur2Attaquant) > 100)
            {
                Assert.Fail("Un joueur semble favorisé au tirage au sort de départ");
            }
        }
        [TestMethod]
        public void Phase1_4_PartieDeBatailleNavale_IntervertirLesRôlesDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1, joueur2);
            partie.ChoisirLesRôlesDeDépartDesJoueurs();
            IContratDuJoueurDeBatailleNavale attaquantActuel = partie.Attaquant;
            IContratDuJoueurDeBatailleNavale défenseurActuel = partie.Défenseur;
            for (int x = 0; x < 100; x++)
            {
                partie.IntervertirLesRôlesDesJoueurs();
                if (attaquantActuel == partie.Attaquant)
                {
                    Assert.Fail("L'attaquant n'a pas changé après l'appel à IntervertirLesRôlesDesJoueurs()");
                }
                Assert.AreEqual(défenseurActuel, partie.Attaquant, "Incohérence après l'interversion des rôles des joueurs");
                attaquantActuel = partie.Attaquant;
                défenseurActuel = partie.Défenseur;
            }
        }
        [TestMethod]
        public void Phase1_5_PartieDeBatailleNavale_JouerLaPartie()
        {
            for (int x = 0; x < 100; x++)
            {
                try
                {
                    IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
                    IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
                    PartieDeBatailleNavale partie = new
                    PartieDeBatailleNavale(joueur1, joueur2);
                    partie.ChoisirLesRôlesDeDépartDesJoueurs();
                    partie.PréparerLaBataille();
                    partie.JouerLaPartie();
                }
                catch (Exception)
                {
                    Assert.Fail("Il semble encore y avoir des anomalies dans le déroulement de la partie...");
                }
            }

        }

    }
}