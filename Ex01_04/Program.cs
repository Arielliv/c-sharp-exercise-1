using System;
using System.Linq;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            handleUserInputAnalysis();
            waitForUserInput();
        }
        private static void waitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void handleUserInputAnalysis()
        {
            string userInputAsString;
            int userInputAsInt;
            StringBuilder inputAnalysis = new StringBuilder();

            userInputAsString = getUserInput();
            inputAnalysis.Append(palindromeCheck(userInputAsString));
            inputAnalysis.Append(Environment.NewLine);

            if (isStringContainsNumbersOnly(userInputAsString))
            {
                userInputAsInt = int.Parse(userInputAsString);
                inputAnalysis.Append(numberDivisibleBy3Check(userInputAsInt));
            }
            else
            {
                inputAnalysis.Append(amountOfUpperCaseLetters(userInputAsString));
            }

            Console.WriteLine(inputAnalysis);
        }

        private static string getUserInput()
        {
            Console.Write("Please enter a string of 6 characters: ");
            string userInput = Console.ReadLine();

            while (!isUserInputValid(userInput))
            {
                Console.Write("Your input is invalid, please enter a string of 6 characters: ");
                userInput = Console.ReadLine();
            }

            return userInput;
        }
        private static bool isStringContainsNumbersOnly(string i_String)
        {
            return i_String.All(Char.IsDigit);
        }

        private static bool isStringContainsLettersOnly(string i_String)
        {
            return i_String.All(Char.IsLetter);
        }

        private static bool isUserInputValid(string i_UserInput)
        {
            return i_UserInput.Length == 6 && 
                (isStringContainsNumbersOnly(i_UserInput) || isStringContainsLettersOnly(i_UserInput));
        }
        private static string numberDivisibleBy3Check(int i_number)
        {
            if (i_number % 3 == 0)
            {
                return "The number is divisible by 3 without remainder.";
            } 
            else
            {
                return "The number is not divisible by 3 without remainder.";
            } 
        }

        private static string amountOfUpperCaseLetters(string i_Value)
        {
            int amountOfUpperCaseLetters = 0;

            for (int i = 0; i < i_Value.Length; i++)
            {
                if(Char.IsUpper(i_Value[i]))
                {
                    amountOfUpperCaseLetters++;
                }
            }

            return string.Format("The number of upper case letters is: {0}", amountOfUpperCaseLetters);
        }

        private static string palindromeCheck(string i_StringToCheck)
        {
            bool isPalindrome = isStringPalindrome(i_StringToCheck, 0, i_StringToCheck.Length - 1);

            if(isPalindrome)
            {
                return "The string is a palindrome.";
            }
            else
            {
                return "The string is not a palindrome.";
            }
        }
        private static bool isStringPalindrome(string i_StringToCheck, int i_startingCharIndex, int i_endingCharIndex)
        {
            bool isPalindrome = true;

            if(i_startingCharIndex == i_endingCharIndex || i_endingCharIndex < i_startingCharIndex)
            {
                return isPalindrome;
            }
   
            if(i_StringToCheck[i_startingCharIndex] != i_StringToCheck[i_endingCharIndex])
            {
                isPalindrome = false;
            }
            else
            {
                isPalindrome = isStringPalindrome(i_StringToCheck, i_startingCharIndex + 1, i_endingCharIndex - 1);
            }

            return isPalindrome;
        }
    }
}
