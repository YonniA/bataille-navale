﻿using BatailleNavale;
using MoteurDeBatailleNavale;
using System.Reflection;

namespace TestDuMoteurDeBatailleNavale
{
    [TestClass]
    public class Test_Phase_2
    {
        [TestMethod]
        public void Phase_2_1_UneSectionDeNavire()
        {
            Type t = typeof(UneSectionDeNavire);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans paramètre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsTrue(constructeurParDefautPublic, "Le constructeur de UneSectionDeNavire par défaut doit être public.");
            UneSectionDeNavire section = new UneSectionDeNavire();
            Assert.AreEqual(section.Etat, EtatDeSectionDeNavire.Intact, "L'état doit être initialisé à Intact");
            Assert.IsNotNull(section.Position, "La position ne peut pas être null");
            Assert.AreEqual(section.Position, new CoordonnéesDeBatailleNavale('A', 1), "La position doit être initialisée avec A1 ");
        }

        [TestMethod]
        public void Phase_2_2_UnNavire()
        {
            Type t = typeof(UnNavire);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans paramètre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsFalse(constructeurParDefautPublic, "Le constructeur de UnNavire par défaut ne doit pas être public.");
            bool testConstructeurNomNull = false;
            try
            {
                UnNavire testConstructeur = new UnNavire(null, 5);
            }
            catch (ArgumentNullException)
            {
                testConstructeurNomNull = true;
            }
            Assert.IsTrue(testConstructeurNomNull, "Le nom du navire ne peut pas être null");
            bool testConstructeurNomVide = false;
            try
            {
                UnNavire testConstructeur = new UnNavire("", 5);
            }
            catch (ArgumentNullException)
            {
                testConstructeurNomVide = true;
            }
            Assert.IsTrue(testConstructeurNomVide, "Le nom du navire ne peut pas être vide");

            bool testNbSectionValide = false;
            try
            {
                for (byte s = 0; s < 2; s++)
                {
                     UnNavire testConstructeur = new UnNavire("NomValide", s);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                testNbSectionValide = true;
            }
            Assert.IsTrue(testNbSectionValide, "Le nombre de section ne peut être inférieur à 2");
            try
            {
                for (byte s = 6; s < byte.MaxValue; s++)
                {
                    UnNavire testConstructeur = new UnNavire("NomValide", s);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                testNbSectionValide = true;
            }
            Assert.IsTrue(testNbSectionValide, "Le nombre de section ne peut être supérieur à 5");
             for (byte taille = 2; taille < 6; taille++)
            {
                try
                {
                    UnNavire navireDeTailleCorrecte = new UnNavire("MonNavire",
                   taille);
                    Assert.AreEqual(navireDeTailleCorrecte.Sections.Length, taille,
                   "Le nombre de sections doit être initialisé par le constructeur");
                }
                catch
                {
                    Assert.Fail("La construction du navire doit accepter une taille entre 2 minimum et 5 maximum");
                }
            }
            UnNavire navire = new UnNavire("Nom_TEST", 5);
            Assert.AreEqual(navire.Nom, "Nom_TEST", "Le nom du navire doit être initialisé par le constructeur");
        }
    }
}