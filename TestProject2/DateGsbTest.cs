using WSGSB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///Classe de test pour DateGsbTest, destinée à contenir tous
    ///les tests unitaires DateGsbTest
    ///</summary>
    [TestClass()]
    public class DateGsbTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        // 
        //Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test pour entre
        ///</summary>
        [TestMethod()]
        public void entreTest()
        {
            int dayA = 1; // TODO: initialisez à une valeur appropriée
            int dayB = 10; // TODO: initialisez à une valeur appropriée
            bool expected = false; // TODO: initialisez à une valeur appropriée
            bool actual;
            actual = DateGsb.entre(dayA, dayB);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour entre
        ///</summary>
        [TestMethod()]
        public void entreTest1()
        {
            int dayA = 1; // TODO: initialisez à une valeur appropriée
            int dayB = 10; // TODO: initialisez à une valeur appropriée
            DateTime date = new DateTime(2008,12,11); // TODO: initialisez à une valeur appropriée
            bool expected = false; // TODO: initialisez à une valeur appropriée
            bool actual;
            actual = DateGsb.entre(dayA, dayB, date);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getAnnMoisPrecedent
        ///</summary>
        [TestMethod()]
        public void getAnnMoisPrecedentTest()
        {
            string expected = "201501"; // TODO: initialisez à une valeur appropriée
            string actual;
            actual = DateGsb.getAnnMoisPrecedent();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getAnnMoisPrecedent
        ///</summary>
        [TestMethod()]
        public void getAnnMoisPrecedentTest1()
        {
            DateTime date = new DateTime(2015,1,1); // TODO: initialisez à une valeur appropriée
            string expected = "201412"; // TODO: initialisez à une valeur appropriée
            string actual;
            actual = DateGsb.getAnnMoisPrecedent(date);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getMoisPrecedent
        ///</summary>
        [TestMethod()]
        public void getMoisPrecedentTest()
        {
            string expected = "01"; // TODO: initialisez à une valeur appropriée
            string actual;
            actual = DateGsb.getMoisPrecedent();
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getMoisPrecedent
        ///</summary>
        [TestMethod()]
        public void getMoisPrecedentTest1()
        {
            DateTime date = new DateTime(2015,1,1); // TODO: initialisez à une valeur appropriée
            string expected = "12"; // TODO: initialisez à une valeur appropriée
            string actual;
            actual = DateGsb.getMoisPrecedent(date);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getMoisSuivant
        ///</summary>
        [TestMethod()]
        public void getMoisSuivantTest()
        {
            string expected = "03"; // TODO: initialisez à une valeur appropriée
            string actual;
            actual = DateGsb.getMoisSuivant();
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getMoisSuivant
        ///</summary>
        [TestMethod()]
        public void getMoisSuivantTest1()
        {
            DateTime date = new DateTime(2008,12,1); // TODO: initialisez à une valeur appropriée
            string expected = "01"; // TODO: initialisez à une valeur appropriée
            string actual;
            actual = DateGsb.getMoisSuivant(date);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }
    }
}
