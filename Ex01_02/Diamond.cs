using System;

namespace Ex01_02
{
    class Diamond
    {
        private int m_DiamondSize;

        public Diamond(int i_DiamondSize)
        {
            m_DiamondSize = i_DiamondSize;
        }

        private static void spaces(int numberOfSpaces)
        {
            if (numberOfSpaces == 0)
            {
                return;
            }

            Console.Write(" ");
            spaces(numberOfSpaces - 1);
        }

        private static void asterisks(int numberOfAsterisks)
        {
            if (numberOfAsterisks == 0)
            {
                return;
            }

            Console.Write("* ");
            asterisks(numberOfAsterisks - 1);
        }

        private static void trinagle(int rowNumber, int totalRowsNumber)
        {
            if (rowNumber == 0)
            {
                return;
            }

            spaces(rowNumber - 1);
            asterisks(totalRowsNumber - rowNumber + 1);
            Console.WriteLine("");
            trinagle(rowNumber - 1, totalRowsNumber);
        }

        private static void reverseTrinagle(int rowNumber, int totalRowsNumber)
        {
            if (rowNumber == 0)
            {
                return;
            }

            spaces(totalRowsNumber - rowNumber + 1);
            asterisks(rowNumber - 1);
            Console.WriteLine("");
            reverseTrinagle(rowNumber - 1, totalRowsNumber);
        }

        public void Draw()
        {
            trinagle(m_DiamondSize, m_DiamondSize);
            reverseTrinagle(m_DiamondSize, m_DiamondSize);
        }
    }
}
