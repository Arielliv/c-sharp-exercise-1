using System;
using Ex01_02;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            int diamondSize = getUserInput();
            Diamond userDiamond = new Diamond(diamondSize);

            userDiamond.Draw();
            waitForUserInput();
        }

        private static int getUserInput()
        {
            bool isValidSizeInput = false;
            int diamondSize = 0;
            string userInputSize;

            Console.Write("Enter the size of the diamond: ");
            userInputSize = Console.ReadLine();

            while (!isValidSizeInput)
            {
                if (int.TryParse(userInputSize, out diamondSize))
                {
                    isValidSizeInput = true;
                }
                else
                {
                    Console.Write("You've entered a wrong number, please try again:");
                    userInputSize = Console.ReadLine();
                }
            }
             
            return diamondSize;
        }

        private static void waitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
