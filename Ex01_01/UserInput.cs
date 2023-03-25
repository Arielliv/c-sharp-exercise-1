using System;

namespace Ex01_01
{
    public class UserInput
    {
        private const int k_AmountOfDigits = 8;
        private readonly int r_AmountOfNumbers;
        private string[] m_BinaryNumbersInput;

        public UserInput(int i_AmountOfNumbers)
        {
            r_AmountOfNumbers = i_AmountOfNumbers;
            m_BinaryNumbersInput = new string[i_AmountOfNumbers];
        }

        public void GetUserInput()
        {
            string userInput;
            string userMessage =
                string.Format("Please enter {0} binary numbers with 8 digits each:",
                    r_AmountOfNumbers);

            Console.WriteLine(userMessage);
            for (int i = 0; i < r_AmountOfNumbers; i++)
            {
                userInput = Console.ReadLine();
                while (!validateUserInput(userInput))
                {
                    Console.WriteLine("Your input is invalid, please enter again...");
                    userInput = Console.ReadLine();
                }

                m_BinaryNumbersInput[i] = userInput;
            }
        }

        public void UserInputNumbersStatistics()
        {
            int[] decimalNumbersInput = getDecimalNumbersInput();

            Array.Sort(decimalNumbersInput);
            Array.Reverse(decimalNumbersInput);
            decimalInputNumbers(decimalNumbersInput);
            averageOfZeroAndOneDigits();
            amountOfNumbersDividedBy4(decimalNumbersInput);
            amountOfDescendingNumbers(decimalNumbersInput);
            amountOfPalindromeNumbers(decimalNumbersInput);
        }

        private bool validateUserInput(string i_BinaryNumber)
        {
            bool isBinaryNumberValid = true;

            if (i_BinaryNumber.Length != k_AmountOfDigits)
            {
                isBinaryNumberValid = false;
            }
            else
            {
                for (int i = 0; i < k_AmountOfDigits; i++)
                {
                    if (i_BinaryNumber[i] != '0' && i_BinaryNumber[i] != '1')
                    {
                        isBinaryNumberValid = false;
                    }
                }
            }

            return isBinaryNumberValid;
        }

        private int convertBinaryNumerToDecimal(string i_BinaryNumber)
        {
            int decimalResult = 0;

            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    decimalResult += (int)Math.Pow(2, i_BinaryNumber.Length - 1 - i);
                }
            }

            return decimalResult;
        }

        private int[] getDecimalNumbersInput()
        {
            int[] decimalNumbersInput = new int[m_BinaryNumbersInput.Length];

            for (int i = 0; i < r_AmountOfNumbers; i++)
            {
                decimalNumbersInput[i] = convertBinaryNumerToDecimal(m_BinaryNumbersInput[i]);
            }

            return decimalNumbersInput;
        }

        private int getAmountOfDigitAppearances(string i_BinaryNumber, char i_Digit)
        {
            int amountOfDigitAppearances = 0;

            for (int i = 0; i < k_AmountOfDigits; i++)
            {
                if (i_BinaryNumber[i] == i_Digit)
                {
                    amountOfDigitAppearances++;
                }
            }

            return amountOfDigitAppearances;
        }

        private bool isNumberDivideByNumber(int i_decimalNumber, int i_Number)
        {
            return i_decimalNumber % i_Number == 0;
        }

        private bool isNumberDigitsPalindrome(int i_decimalNumber)
        {
            string decimalNumberAsString = i_decimalNumber.ToString();
            bool isPalindrome = true;

            for (int i = 0; i < decimalNumberAsString.Length / 2; i++)
            {
                if (decimalNumberAsString[i] != decimalNumberAsString[decimalNumberAsString.Length - i - 1])
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome;
        }

        private bool isNumberDigitsDescendingSeries(int i_decimalNumber)
        {
            int currentDigit;
            int currentDecimalNumber = i_decimalNumber;
            bool isNumberDigitsDescendingSeries = true;

            currentDigit = currentDecimalNumber % 10;
            if (currentDecimalNumber / 10 != 0)
            {
                currentDigit = currentDecimalNumber % 10;
                currentDecimalNumber = currentDecimalNumber / 10;
            }

            while (currentDecimalNumber / 10 != 0 && isNumberDigitsDescendingSeries)
            {
                if (currentDigit > currentDecimalNumber % 10)
                {
                    isNumberDigitsDescendingSeries = false;
                }

                currentDigit = currentDecimalNumber % 10;
                currentDecimalNumber = currentDecimalNumber % 10;
            }

            return isNumberDigitsDescendingSeries;
        }

        private void amountOfPalindromeNumbers(int[] i_decimalNumbersInput)
        {
            int totalAmountOfPalindromeNumbers = 0;
            string message;

            for (int i = 0; i < r_AmountOfNumbers; i++)
            {
                if (isNumberDigitsPalindrome(i_decimalNumbersInput[i]))
                {
                    totalAmountOfPalindromeNumbers++;
                }
            }

            message = string.Format(
                "The amount of numbers that their digits are palindrome are: {0}",
                totalAmountOfPalindromeNumbers);
            Console.WriteLine(message);
        }

        private void amountOfDescendingNumbers(int[] i_decimalNumbersInput)
        {
            int totalAmountOfNumbersWithDescendingDigitsSeries = 0;
            string message;

            for (int i = 0; i < r_AmountOfNumbers; i++)
            {
                if (isNumberDigitsDescendingSeries(i_decimalNumbersInput[i]))
                {
                    totalAmountOfNumbersWithDescendingDigitsSeries++;
                }
            }

            message = string.Format(
                "The amount of numbers that their digits are descending series: {0}",
                totalAmountOfNumbersWithDescendingDigitsSeries);
            Console.WriteLine(message);
        }

        private void amountOfNumbersDividedBy4(int[] i_decimalNumbersInput)
        {
            int totalAmountOfNumbersDividedBy4 = 0;
            string message;

            for (int i = 0; i < r_AmountOfNumbers; i++)
            {
                if (isNumberDivideByNumber(i_decimalNumbersInput[i], 4))
                {
                    totalAmountOfNumbersDividedBy4++;
                }
            }

            message = string.Format(
                "The amount of numbers that are divided by 4 are: {0}",
                totalAmountOfNumbersDividedBy4);
            Console.WriteLine(message);
        }

        private void averageOfZeroAndOneDigits()
        {
            int totalAmountOfZeroDigit = 0;
            int totalAmountOfOneDigit = 0;
            double averageOfZeroDigit = 0;
            double averageOfOneDigit = 0;
            string message;

            for (int i = 0; i < r_AmountOfNumbers; i++)
            {
                totalAmountOfZeroDigit += getAmountOfDigitAppearances(m_BinaryNumbersInput[i], '0');
                totalAmountOfOneDigit += getAmountOfDigitAppearances(m_BinaryNumbersInput[i], '1');
            }

            averageOfZeroDigit = totalAmountOfZeroDigit / r_AmountOfNumbers;
            averageOfOneDigit = totalAmountOfOneDigit / r_AmountOfNumbers;
            message = string.Format(
                @"The average of 0 digit is {0}
The average of 1 digit is {1}",
                averageOfZeroDigit, averageOfOneDigit);
            Console.WriteLine(message);
        }

        private void decimalInputNumbers(int[] i_decimalNumbersInput)
        {
            Console.Write("The decimal numbers in descending order:");
            foreach (int decimalNumber in i_decimalNumbersInput)
            {
                Console.Write(" " + decimalNumber);
            }

            Console.WriteLine();
        }
    }
}