using System;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            UserInput userInput = new UserInput(3);
            userInput.GetUserInput();
            userInput.UserInputNumbersStatistics();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}