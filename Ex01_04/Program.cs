using System;
using System.Linq;
using System.Text;

namespace Ex01_04
{
    public class Program
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
            return i_String.All(char.IsDigit);
        }

        private static bool isStringContainsLettersOnly(string i_String)
        {
            return i_String.All(char.IsLetter);
        }

        private static bool isUserInputValid(string i_UserInput)
        {
            return i_UserInput.Length == 6 && 
                (isStringContainsNumbersOnly(i_UserInput) || isStringContainsLettersOnly(i_UserInput));
        }

        private static string numberDivisibleBy3Check(int i_Number)
        {
            string divisibleBy3Message;

            if (i_Number % 3 == 0)
            {
                divisibleBy3Message = "The number is divisible by 3 without remainder.";
            } 
            else
            {
                divisibleBy3Message = "The number is not divisible by 3 without remainder.";
            }

            return divisibleBy3Message;
        }

        private static string amountOfUpperCaseLetters(string i_Value)
        {
            int amountOfUpperCaseLetters = 0;

            for (int i = 0; i < i_Value.Length; i++)
            {
                if(char.IsUpper(i_Value[i]))
                {
                    amountOfUpperCaseLetters++;
                }
            }

            return string.Format("The number of upper case letters is: {0}", amountOfUpperCaseLetters);
        }

        private static string palindromeCheck(string i_StringToCheck)
        {
            bool isPalindrome = isStringPalindrome(i_StringToCheck, 0, i_StringToCheck.Length - 1);
            string isPalindromMessage;

            if(isPalindrome)
            {
                isPalindromMessage = "The string is a palindrome.";
            }
            else
            {
                isPalindromMessage = "The string is not a palindrome.";
            }

            return isPalindromMessage;
        }

        private static bool isStringPalindrome(string i_StringToCheck, int i_StartingCharIndex, int i_EndingCharIndex)
        {
            bool isPalindrome = true;

            if(i_StartingCharIndex == i_EndingCharIndex || i_EndingCharIndex < i_StartingCharIndex)
            {
                return isPalindrome;
            }
   
            if(i_StringToCheck[i_StartingCharIndex] != i_StringToCheck[i_EndingCharIndex])
            {
                isPalindrome = false;
            }
            else
            {
                isPalindrome = isStringPalindrome(i_StringToCheck, i_StartingCharIndex + 1, i_EndingCharIndex - 1);
            }

            return isPalindrome;
        }
    }
}
