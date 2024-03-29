﻿using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            getDiamondSizeAndDraw();
            waitForUserInput();
        }

        private static void getDiamondSizeAndDraw()
        {
            int diamondSize = getUserInput();

            Ex01_02.Program.DrawDiamond(diamondSize);
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
                if (int.TryParse(userInputSize, out diamondSize) && diamondSize > 0)
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
