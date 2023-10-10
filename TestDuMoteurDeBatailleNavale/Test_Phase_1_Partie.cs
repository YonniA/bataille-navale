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
    }
}