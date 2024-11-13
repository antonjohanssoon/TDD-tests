using Functionality;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(17, "17")]
        public void TestFizzBuzzGame(int input, string expectedResult)
        {
            //Arrange
            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                //Act
                FizzBuzz.FizzBuzzGame(input);

                //Assert
                string actualResult = stringWriter.ToString().Trim();
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}