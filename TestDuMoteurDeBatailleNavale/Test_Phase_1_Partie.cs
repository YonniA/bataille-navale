using BatailleNavale;
using MoteurDeBatailleNavale;
using System.Reflection;

namespace TestDuMoteurDeBatailleNavale
{
    [TestClass]
    public class Test_Phase_1_Partie
    {
        [TestMethod]
        public void Phase1_1_Coordonn�esDeBatailleNavale()
        {
            // v�rification du constructeur par d�faut non public
            Type t = typeof(Coordonn�esDeBatailleNavale);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    // v�rification de visibilit�
                    Assert.IsFalse(constructeur.IsPublic, "Le constructeur par d�faut ne doit pas �tre public.");
                }
            }

            // v�rification que les param�tres hors plage valide produisent une exception IndexOutOfRangeException
            bool ThrowException = false;
            try
            {
                ThrowException = false;
                for (char c = char.MinValue; c < 'A'; c++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                    Coordonn�esDeBatailleNavale(c, 1);
                }
                for (char c = (char)('J' + 1); c < char.MaxValue; c++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                    Coordonn�esDeBatailleNavale(c, 1);
                }
                Coordonn�esDeBatailleNavale coordonn�eInvalide2 = new
                Coordonn�esDeBatailleNavale('A', 0);
                for (byte l = 11; l < byte.MaxValue; l++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                    Coordonn�esDeBatailleNavale('A', l);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de Coordonn�esDeBatailleNavale ne doit accepter que des colonnes de 'A' � 'J' et des lignes de 1 � 10");

            // v�rification que les param�tres dans la plage valide ne produisent pas d'exception
            try
            {
                ThrowException = false;
                for (char c = 'A'; c <= 'J'; c++)
                {
                    for (byte l = 1; l <= 10; l++)
                    {
                        Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                        Coordonn�esDeBatailleNavale(c, l);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsFalse(ThrowException, "La construction de Coordonn�esDeBatailleNavale doit accepter des colonnes entre 'A' et 'J' et des lignes entre 1 et 10");

            // v�rification de la m�thode Equals
            try
            {
                Coordonn�esDeBatailleNavale uneInstance = new
                Coordonn�esDeBatailleNavale('C', 5);
                uneInstance.Equals(null);
                uneInstance.Equals(new object());
                uneInstance.Equals(uneInstance);
            }
            catch
            {
                Assert.Fail("Le test d'�galit� ne doit pas provoquer d'exception");
            }
            Assert.IsTrue(new Coordonn�esDeBatailleNavale('C', 5).Equals(new Coordonn�esDeBatailleNavale('C', 5)), "L'�galit� C5 avec C5 doit �tre vraie");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals(null), "L'�galit� avec null doit �tre fausse");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals(new Coordonn�esDeBatailleNavale('A', 2)), "L'�galit� A1 avec A2 doit �tre fausse");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals("A1"), "L'�galit� entre deux types diff�rents doit �tre fausse");
        }
        public class joueurTest : IContratDuJoueurDeBatailleNavale
        {
            public joueurTest(string pseudo)
            {
                Pseudo = pseudo;
            }
            public string Pseudo { get; private set; }
            public Coordonn�esDeBatailleNavale Attaquant_ChoisirLesCoordonn�esDeTir()
            {
                return new Coordonn�esDeBatailleNavale('A', 1);
            }
            public void Attaquant_G�rerLeR�sultatDuTir(Coordonn�esDeBatailleNavale
           coordonn�esDuTir, R�sultatDeTir r�sultatDuTir)
            {
            }
            public R�sultatDeTir
           D�fenseur_FournirLeR�sultatDuTir(Coordonn�esDeBatailleNavale coordonn�esDuTir)
            {
                return R�sultatDeTir.Touch�Coul�Final;
            }
            public void Pr�parerLaBataille()
            {
            }
        }
        [TestMethod]
        public void Phase1_2_PartieDeBatailleNavale_Constructeur()
        {
            // v�rification du constructeur public
            Type t = typeof(PartieDeBatailleNavale);
            ConstructorInfo constructeurPublique = t.GetConstructor(new Type[] {
            typeof(IContratDuJoueurDeBatailleNavale), typeof(IContratDuJoueurDeBatailleNavale) });
            Assert.IsNotNull(constructeurPublique, "PartieDeBatailleNavale doit avoir un constructeur public attendant en param�tre 2 instance de IContratDuJoueurDeBatailleNavale");
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
            Assert.IsTrue(ThrowException, "La construction de PartieDeBatailleNavale ne doit pas accepter les param�tes null");
        }
        [TestMethod]
        public void Phase1_3_PartieDeBatailleNavale_ChoisirLesR�lesDeD�partDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
            joueur2);
            // partie.ChoisirLesR�lesDeD�partDesJoueurs();
            // IContratDuJoueurDeBatailleNavale attaquantDeD�part = partie.Attaquant;
            int joueur1Attaquant = 0;
            int joueur2Attaquant = 0;
            for (int x = 0; x < 1000; x++)
            {
                partie.ChoisirLesR�lesDeD�partDesJoueurs();
                Assert.IsNotNull(partie.Attaquant, "L'attaquant ne peut pas �tre null");

                Assert.IsNotNull(partie.D�fenseur, "Le d�fenseur ne peut pas �tre null");
                if (partie.Attaquant == joueur1)
                {
                    joueur1Attaquant++;
                    Assert.AreEqual(partie.D�fenseur, joueur2, "Incoh�rence entre joueur ataquant et d�fenseur");
                }
                else if (partie.Attaquant == joueur2)
                {
                    joueur2Attaquant++;
                    Assert.AreEqual(partie.D�fenseur, joueur1, "Incoh�rence entre joueur ataquant et d�fenseur");
                }
                else
                {
                    Assert.Fail("Incoh�rence entre joueur ataquant et d�fenseur");
                }
            }
            if (Math.Abs(joueur1Attaquant - joueur2Attaquant) > 100)
            {
                Assert.Fail("Un joueur semble favoris� au tirage au sort de d�part");
            }
        }
        [TestMethod]
        public void Phase1_4_PartieDeBatailleNavale_IntervertirLesR�lesDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1, joueur2);
            partie.ChoisirLesR�lesDeD�partDesJoueurs();
            IContratDuJoueurDeBatailleNavale attaquantActuel = partie.Attaquant;
            IContratDuJoueurDeBatailleNavale d�fenseurActuel = partie.D�fenseur;
            for (int x = 0; x < 100; x++)
            {
                partie.IntervertirLesR�lesDesJoueurs();
                if (attaquantActuel == partie.Attaquant)
                {
                    Assert.Fail("L'attaquant n'a pas chang� apr�s l'appel � IntervertirLesR�lesDesJoueurs()");
                }
                Assert.AreEqual(d�fenseurActuel, partie.Attaquant, "Incoh�rence apr�s l'interversion des r�les des joueurs");
                attaquantActuel = partie.Attaquant;
                d�fenseurActuel = partie.D�fenseur;
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
                    partie.ChoisirLesR�lesDeD�partDesJoueurs();
                    partie.Pr�parerLaBataille();
                    partie.JouerLaPartie();
                }
                catch (Exception)
                {
                    Assert.Fail("Il semble encore y avoir des anomalies dans le d�roulement de la partie...");
                }
            }

        }

    }
}