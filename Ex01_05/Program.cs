using System;
using System.Text;

namespace Ex01_05
{
    public static class Program
    {
        private const int k_NumberOfDigits = 6;

        public static void Main()
        {
            entry();
            waitForUserInput();
        }
        private static void waitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void entry()
        {
            string userInput = getUserInput();
            int userInputNumber = int.Parse(userInput);
            int amountOfBiggerDigitsThanUnityDigit = getAmountOfBiggerDigitsThanUnityDigit(userInput);
            int smallestDigitInNumber = getSmallestDigitInNumber(userInputNumber);
            int amountOfDigitsDivisibleBy3 = getAmountOfDigitsDivisibleBy3(userInput);
            int digitsAvarage = getDigitsAvarage(userInputNumber);
            string inputAnalysisMessage = string.Format(@"The amount of bigger digits than the unity digit is: {0}.
The smallest digit in the number is: {1}.
The amount of digits divisible by 3 is: {2}.
The digits avarage is: {3}.", amountOfBiggerDigitsThanUnityDigit, smallestDigitInNumber, amountOfDigitsDivisibleBy3, digitsAvarage);
            
            Console.WriteLine(inputAnalysisMessage);
        }
        private static string getUserInput()
        {
            Console.Write("Please enter an integer number of 6 digits: ");
            string userInput = Console.ReadLine();

            while (!isUserInputValid(userInput))
            {
                Console.Write("Your input is invalid, please enter an integer number of 6 digits: ");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static bool isUserInputValid(string i_UserInput)
        {
            int userInputNumber;

            return i_UserInput.Length == k_NumberOfDigits && int.TryParse(i_UserInput, out userInputNumber);
        }
        public static int getAmountOfBiggerDigitsThanUnityDigit(string i_Number)
        {
            int amountOfBiggerDigitsThanUnityDigit = 0;

            for (int i = 0; i < k_NumberOfDigits - 1; i++)
            {
                if(i_Number[i] > i_Number[k_NumberOfDigits - 1])
                {
                    amountOfBiggerDigitsThanUnityDigit++;
                }
            }

            return amountOfBiggerDigitsThanUnityDigit;
        }

        public static int getSmallestDigitInNumber(int i_Number)
        {
            int minDigitInNumber = 9;
            int restOfNumber = i_Number;
            int currentDigit;

            while (restOfNumber != 0)
            {
                currentDigit = restOfNumber % 10;
                minDigitInNumber = Math.Min(currentDigit, minDigitInNumber);
                restOfNumber = restOfNumber / 10;
            }

            return minDigitInNumber;
        }

        private static int getAmountOfDigitsDivisibleBy3(string i_Number)
        {
            int amountOfDigitsDivisibleBy3 = 0;

            for (int i = 0; i < k_NumberOfDigits; i++)
            {
                if (i_Number[i] % 3 == 0)
                {
                    amountOfDigitsDivisibleBy3++;
                }
            }

            return amountOfDigitsDivisibleBy3;
        }

        private static int getDigitsAvarage(int i_Number)
        {
            int sumOfDigits = 0;

            for (int i = 0; i < k_NumberOfDigits; i++)
            {
                sumOfDigits += i_Number % 10;
                i_Number /= 10;
            }

            return sumOfDigits / k_NumberOfDigits;
        }
    }
}
