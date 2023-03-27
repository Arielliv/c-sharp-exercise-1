using System;

namespace Ex01_02
{
    class Program
    {
        static void Main(string[] args)
        {

            Diamond userDiamond = new Diamond(9);
            userDiamond.Draw();
            waitForUserInput();
        }

        private static void waitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

        