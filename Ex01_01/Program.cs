using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        private const int k_AmountOfDigits = 8;

        public static void Main()
        {
            handleUserInputAnalysis(3);
            waitForUserInput();
        }

        private static void handleUserInputAnalysis(int i_AmountOfNumbers)
        {
            string[] binaryNumbersInput = new string[i_AmountOfNumbers];
            string userInput;

            string userMessage = string.Format("Please enter {0} binary numbers with 8 digits each:",
                    i_AmountOfNumbers);

            Console.WriteLine(userMessage);
            for (int i = 0; i < i_AmountOfNumbers; i++)
            {
                userInput = Console.ReadLine();
                while (!validateUserInput(userInput))
                {
                    Console.WriteLine("Your input is invalid, please enter again...");
                    userInput = Console.ReadLine();
                }

                binaryNumbersInput[i] = userInput;
            }

            showUserInputNumbersStatistics(i_AmountOfNumbers, binaryNumbersInput);
        }

        private static void showUserInputNumbersStatistics(int i_AmountOfNumbers, string[] i_BinaryNumbersInput)
        {
            int[] decimalNumbersInput = getDecimalNumbersInput(i_BinaryNumbersInput);
            StringBuilder inputAnalysis = new StringBuilder();

            Array.Sort(decimalNumbersInput);
            Array.Reverse(decimalNumbersInput);
            inputAnalysis.Append(getDecimalInputNumbersInDescendingOrder(decimalNumbersInput));
            inputAnalysis.Append(getAverageOfZeroAndOneDigits(i_BinaryNumbersInput));
            inputAnalysis.Append(getAmountOfNumbersDivisibleBy4(decimalNumbersInput));
            inputAnalysis.Append(getAmountOfDescendingNumbers(decimalNumbersInput));
            inputAnalysis.Append(getAmountOfPalindromeNumbers(decimalNumbersInput));
            Console.WriteLine(inputAnalysis);
        }

        private static bool validateUserInput(string i_BinaryNumber)
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

        private static int convertBinaryNumerToDecimal(string i_BinaryNumber)
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

        private static int[] getDecimalNumbersInput(string[] i_BinaryNumbersInput)
        {
            int[] decimalNumbersInput = new int[i_BinaryNumbersInput.Length];

            for (int i = 0; i < i_BinaryNumbersInput.Length; i++)
            {
                decimalNumbersInput[i] = convertBinaryNumerToDecimal(i_BinaryNumbersInput[i]);
            }

            return decimalNumbersInput;
        }

        private static int getAmountOfDigitAppearances(string i_BinaryNumber, char i_Digit)
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

        private static bool isNumberDivideByNumber(int i_decimalNumber, int i_Number)
        {
            return i_decimalNumber % i_Number == 0;
        }

        private static bool isNumberDigitsPalindrome(int i_decimalNumber)
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

        private static bool isNumberDigitsDescendingSeries(int i_decimalNumber)
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

        private static string getAmountOfPalindromeNumbers(int[] i_decimalNumbersInput)
        {
            int amountOfPalindromeNumbers = 0;
            string amountOfPalindromeNumbersMessage;

            for (int i = 0; i < i_decimalNumbersInput.Length; i++)
            {
                if (isNumberDigitsPalindrome(i_decimalNumbersInput[i]))
                {
                    amountOfPalindromeNumbers++;
                }
            }

            amountOfPalindromeNumbersMessage = string.Format(
                @"The amount of numbers that their digits are palindrome are: {0}
",
                amountOfPalindromeNumbers);
            return amountOfPalindromeNumbersMessage;
        }

        private static string getAmountOfDescendingNumbers(int[] i_decimalNumbersInput)
        {
            int amountOfNumbersWithDescendingDigitsSeries = 0;
            string amountOfNumbersWithDescendingDigitsSeriesMessage;

            for (int i = 0; i < i_decimalNumbersInput.Length; i++)
            {
                if (isNumberDigitsDescendingSeries(i_decimalNumbersInput[i]))
                {
                    amountOfNumbersWithDescendingDigitsSeries++;
                }
            }

            amountOfNumbersWithDescendingDigitsSeriesMessage = string.Format(
                @"The amount of numbers that their digits are descending series: {0}
",
                amountOfNumbersWithDescendingDigitsSeries);
            return amountOfNumbersWithDescendingDigitsSeriesMessage;
        }

        private static string getAmountOfNumbersDivisibleBy4(int[] i_decimalNumbersInput)
        {
            int amountOfNumbersDivisibleBy4 = 0;
            string amountOfNumbersDivisibleBy4Message;

            for (int i = 0; i < i_decimalNumbersInput.Length; i++)
            {
                if (isNumberDivideByNumber(i_decimalNumbersInput[i], 4))
                {
                    amountOfNumbersDivisibleBy4++;
                }
            }

            amountOfNumbersDivisibleBy4Message = string.Format(
                @"The amount of numbers that are divided by 4 are: {0}
",
                amountOfNumbersDivisibleBy4);
            return amountOfNumbersDivisibleBy4Message;
        }

        private static string getAverageOfZeroAndOneDigits(string[] i_BinaryNumbersInput)
        {
            int totalAmountOfZeroDigit = 0;
            int totalAmountOfOneDigit = 0;
            double averageOfZeroDigit = 0;
            double averageOfOneDigit = 0;
            string averageOfZeroDigitAndOneDigitMessage;

            for (int i = 0; i < i_BinaryNumbersInput.Length; i++)
            {
                totalAmountOfZeroDigit += getAmountOfDigitAppearances(i_BinaryNumbersInput[i], '0');
                totalAmountOfOneDigit += getAmountOfDigitAppearances(i_BinaryNumbersInput[i], '1');
            }

            averageOfZeroDigit = totalAmountOfZeroDigit / i_BinaryNumbersInput.Length;
            averageOfOneDigit = totalAmountOfOneDigit / i_BinaryNumbersInput.Length;
            averageOfZeroDigitAndOneDigitMessage = string.Format(
                @"The average of 0 digit is {0}
The average of 1 digit is {1}
",
                averageOfZeroDigit, averageOfOneDigit);
            return averageOfZeroDigitAndOneDigitMessage;
        }

        private static string getDecimalInputNumbersInDescendingOrder(int[] i_decimalNumbersInput)
        {
            StringBuilder numbersInDescendingOrder = new StringBuilder();

            numbersInDescendingOrder.Append("The decimal numbers in descending order:");
            foreach (int decimalNumber in i_decimalNumbersInput)
            {
                numbersInDescendingOrder.Append(string.Format(" {0}", decimalNumber));
            }

            return numbersInDescendingOrder.Append(Environment.NewLine).ToString();
        }

        private static void waitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}