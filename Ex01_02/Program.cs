using System;

namespace Ex01_02
{
    public static class Program
    {
        public static void Main()
        {
            DrawDiamond(9);
            waitForUserInput();
        }

        private static void waitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void drawSpaces(int i_NumberOfSpaces)
        {
            if (i_NumberOfSpaces == 0)
            {
                return;
            }

            Console.Write(" ");
            drawSpaces(i_NumberOfSpaces - 1);
        }

        private static void drawAsterisks(int i_NumberOfAsterisks)
        {
            if (i_NumberOfAsterisks == 0)
            {
                return;
            }

            Console.Write("*");
            drawAsterisks(i_NumberOfAsterisks - 1);
        }

        private static void drawTriangle(int i_RowNumber, int i_TotalRowsNumber)
        {
            if (i_RowNumber == 0)
            {
                return;
            }

            drawSpaces(i_RowNumber - 1);

            drawAsterisks(((i_TotalRowsNumber - i_RowNumber) * 2) + 1);
            Console.WriteLine(string.Empty);
            drawTriangle(i_RowNumber - 1, i_TotalRowsNumber);
        }

        private static void drawReverseTriangle(int i_RowNumber, int i_TotalRowsNumber)
        {
            if (i_RowNumber == 0)
            {
                return;
            }

            drawSpaces(i_TotalRowsNumber - i_RowNumber + 1);
            drawAsterisks((i_RowNumber * 2) - 1);
            Console.WriteLine(string.Empty);
            drawReverseTriangle(i_RowNumber - 1, i_TotalRowsNumber);
        }

        public static void DrawDiamond(int i_DiamondSize)
        {
            int triangleHeight = (i_DiamondSize / 2) + 1;
            int ReverseTrinagle = i_DiamondSize / 2;

            drawTriangle(triangleHeight, triangleHeight);
            drawReverseTriangle(ReverseTrinagle, ReverseTrinagle);
        }
    }
}  