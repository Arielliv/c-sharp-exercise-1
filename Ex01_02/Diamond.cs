using System;

namespace Ex01_02
{
    public class Diamond
    {
        private int m_DiamondSize;

        public Diamond(int i_DiamondSize)
        {
            m_DiamondSize = i_DiamondSize;
        }

        private static void drawSpaces(int numberOfSpaces)
        {
            if (numberOfSpaces == 0)
            {
                return;
            }

            Console.Write(" ");
            drawSpaces(numberOfSpaces - 1);
        }

        private static void drawAsterisks(int numberOfAsterisks)
        {
            if (numberOfAsterisks == 0)
            {
                return;
            }

            Console.Write("*");
            drawAsterisks(numberOfAsterisks - 1);
        }

        private static void drawTriangle(int rowNumber, int totalRowsNumber)
        {
            if (rowNumber == 0)
            {
                return;
            }

            drawSpaces(rowNumber - 1);
           
            drawAsterisks((totalRowsNumber - rowNumber)*2 + 1);
            Console.WriteLine("");
            drawTriangle(rowNumber - 1, totalRowsNumber);
        }

        private static void drawReverseTriangle(int rowNumber, int totalRowsNumber)
        {
            if (rowNumber == 0)
            {
                return;
            }

            drawSpaces(totalRowsNumber - rowNumber + 1);
            drawAsterisks(rowNumber*2 - 1);
            Console.WriteLine("");
            drawReverseTriangle(rowNumber - 1, totalRowsNumber);
        }

        public void Draw()
        {
            int triangleHeight = m_DiamondSize / 2 + 1;
            int ReverseTrinagle = m_DiamondSize / 2;

            drawTriangle(triangleHeight, triangleHeight);
            drawReverseTriangle(ReverseTrinagle, ReverseTrinagle);
        }
    }
}

