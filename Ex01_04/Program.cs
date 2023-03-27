using System;
using System.Linq;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            handleUserInput();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void handleUserInput()
        {
            string userInputAsString;
            int userInputAsInt;

            userInputAsString = getUserInput();
            palindromeCheck(userInputAsString);

            if (isStringContainsNumbersOnly(userInputAsString))
            {
                userInputAsInt = int.Parse(userInputAsString);
                numberDivisibleBy3Check(userInputAsInt);
            }
            else
            {
                amountOfUpperCaseLetters(userInputAsString);
            }
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
        private static void numberDivisibleBy3Check(int i_number)
        {
            if (i_number % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3 without remainder");
            } 
            else
            {
                Console.WriteLine("The number is not divisible by 3 without remainder");
            } 
        }

        private static void amountOfUpperCaseLetters(string i_Value)
        {
            int amountOfUpperCaseLetters = 0;
            string messageToUser;

            for (int i = 0; i < i_Value.Length; i++)
            {
                if(Char.IsUpper(i_Value[i]))
                {
                    amountOfUpperCaseLetters++;
                }
            }

            messageToUser = string.Format("The number of upper case letters is: {0}", amountOfUpperCaseLetters);
            Console.WriteLine(messageToUser);
        }

        private static void palindromeCheck(string i_StringToCheck)
        {
            bool isPalindrome = isStringPalindrome(i_StringToCheck, 0, i_StringToCheck.Length - 1);

            if(isPalindrome)
            {
                Console.WriteLine("The string is a palindrome");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome");
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
