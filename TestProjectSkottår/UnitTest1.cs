
using Functionality;

namespace TestProjectSkottår
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2000, true)]
        [TestCase(2400, true)]
        [TestCase(2800, true)]
        public void DetValdaÅretÄrEttSkottårOmDetÄrDelbartMed400(int år, bool förväntatResultat)
        {
            //Arrange
            var skottår = new SkottårKalkylator();

            //Act
            var resultat = skottår.ÄrSkottår(år);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }

        [Test]
        [TestCase(1700, false)]
        [TestCase(1800, false)]
        [TestCase(2100, false)]
        public void DetValdaÅretÄrINTEEttSkottårOmDetÄrDelbartMed100MenINTEMed400(int år, bool förväntatResultat)
        {
            //Arrange
            var inteSkottår = new SkottårKalkylator();

            //Act
            var resultat = inteSkottår.ÄrSkottår(år);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }

        [Test]
        [TestCase(2008, true)]
        [TestCase(2012, true)]
        [TestCase(2016, true)]
        public void DetValdaÅretÄrEttSkottårOmDetÄrDelbartMed4MenINTEMed100(int år, bool förväntatResultat)
        {
            //Arrange
            var skottår = new SkottårKalkylator();

            //Act
            var resultat = skottår.ÄrSkottår(år);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }

        [Test]
        [TestCase(2017, false)]
        [TestCase(2018, false)]
        [TestCase(2020, true)]
        public void DetValdaÅretÄrINTEEttSkottårOmDetINTEÄrDelbartMed4(int år, bool förväntatResultat)
        {
            //Arrange
            var skottår = new SkottårKalkylator();

            //Act
            var resultat = skottår.ÄrSkottår(år);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }

        [Test]
        [TestCase("2024-01-02", 2)]
        [TestCase("2024-01-31", 31)]
        [TestCase("2024-12-31", 366)]
        public void NärFåDagNummerFårEttDatumSåSkallDenReturneraDagenPåÅret(DateTime datum, int förväntatResultat)
        {
            //Arrange
            var skottår = new SkottårKalkylator();

            //Act
            var resultat = skottår.FåDagNummer(datum);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }

        [Test]
        [TestCase("2024-01-02", 1)]
        [TestCase("2024-01-31", 5)]
        [TestCase("2024-12-24", 52)]
        public void NärFåVeckaNummerFårEttDatumSåSkallDenReturneraVeckanPåÅret(DateTime datum, int förväntatResultat)
        {
            //Arrange
            var skottår = new SkottårKalkylator();

            //Act
            var resultat = skottår.FåVeckoNummer(datum);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }

        [Test]
        [TestCase("2024-11-11", "Monday")]
        [TestCase("2024-11-12", "Tuesday")]
        [TestCase("2024-11-13", "Wednesday")]
        public void NärFåVeckoDagFårEttDatumSåSkallDenReturneraVeckodagen(DateTime datum, string förväntatResultat)
        {
            //Arrange
            var skottår = new SkottårKalkylator();

            //Act
            var resultat = skottår.FåVeckoDag(datum);

            //Assert
            Assert.That(resultat, Is.EqualTo(förväntatResultat));
        }
    }
}