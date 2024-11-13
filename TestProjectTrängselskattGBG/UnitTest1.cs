using Functionality;

namespace TestProjectTrängselskattGBG
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2024-05-03 17:10", "Totala avgiften är 13 kr")]
        [TestCase("2024-12-23 15:15", "Totala avgiften är 13 kr")]
        [TestCase("2024-11-11 07:45", "Totala avgiften är 18 kr")]
        [TestCase("2024-11-11 16:59", "Totala avgiften är 18 kr")]
        [TestCase("2024-11-11 18:45", "Totala avgiften är 0 kr")]
        [TestCase("2024-11-11 03:56", "Totala avgiften är 0 kr")]
        [TestCase("2024-11-11 10:56", "Totala avgiften är 8 kr")]
        public void RäknaTotalBelopp_GerTillbakaVilketBeloppManSkallBetalaUnderEnSpecifikTid(string datum, string förväntatResultat)
        {
            //Arrange
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //Act
                TrängselskattGBG.RäknaTotalBelopp(datum);

                //Assert
                string aktuelltResultat = stringWriter.ToString().Trim();
                Assert.AreEqual(förväntatResultat, aktuelltResultat);
            }
        }


        [Test]
        [TestCase("2024-05-03 17:10, 2024-05-03 11:10, 2024-05-03 00:10", "Totala avgiften är 21 kr")]
        public void RäknaTotalBelopp_GerTillbakaFleraTrängselskatter(string datumOchTid, string förväntatResultat)
        {
            //Arrange
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //Act
                TrängselskattGBG.RäknaTotalBelopp(datumOchTid);

                //Assert
                string aktuelltResultat = stringWriter.ToString().Trim();
                Assert.AreEqual(förväntatResultat, aktuelltResultat);
            }
        }

        [Test]
        [TestCase("2024-05-03 17:10, 2024-05-03 11:10, 2024-05-03 00:10, 2024-01-01 15:37, 2024-01-03 15:47, 2024-01-04 15:39", "Totala avgiften är 60 kr")]
        public void RäknaTotalBelopp_GerTillbakaFleraTrängselskatterOchMaxbeloppetÄr60Kr(string datumOchTid, string förväntatResultat)
        {
            //Arrange
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //Act
                TrängselskattGBG.RäknaTotalBelopp(datumOchTid);

                //Assert
                string aktuelltResultat = stringWriter.ToString().Trim();
                Assert.AreEqual(förväntatResultat, aktuelltResultat);
            }
        }

        [Test]
        [TestCase("2024-07-03 17:10", "Totala avgiften är 0 kr")]
        [TestCase("2024-11-10 15:15", "Totala avgiften är 0 kr")]
        [TestCase("2024-11-09 07:45", "Totala avgiften är 0 kr")]

        public void RäknaTotalBelopp_IngenTrängselskattTasUtPåLördagaraSöndagarOchIJuli(string datum, string förväntatResultat)
        {
            //Arrange
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //Act
                TrängselskattGBG.RäknaTotalBelopp(datum);

                //Assert
                string aktuelltResultat = stringWriter.ToString().Trim();
                Assert.AreEqual(förväntatResultat, aktuelltResultat);
            }
        }

        [Test]
        [TestCase("2024-05-03 17:30, 2024-05-03 17:40, 2024-05-03 18:10", "Totala avgiften är 13 kr")]

        public void RäknaTotalBelopp_EndastDyrasteAvgiftenSkallRäknasVidFleraPassagerInom60Minuter(string datum, string förväntatResultat)
        {
            //Arrange
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                //Act
                TrängselskattGBG.RäknaTotalBelopp(datum);

                //Assert
                string aktuelltResultat = stringWriter.ToString().Trim();
                Assert.AreEqual(förväntatResultat, aktuelltResultat);
            }
        }
    }

}