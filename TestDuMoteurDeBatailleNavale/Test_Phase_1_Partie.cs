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
    }
}