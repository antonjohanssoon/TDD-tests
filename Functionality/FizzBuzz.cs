namespace Functionality
{
    public class FizzBuzz
    {
        public static void FizzBuzzGame(int number)
        {
            try
            {
                GetFizzBuzzResult(number);

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }

        }

        private static void GetFizzBuzzResult(int number)
        {
            if (number % 5 == 0 && number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number.ToString());
            }
        }
    }
}
