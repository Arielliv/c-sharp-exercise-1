using System;
using Ex01_02;

class Program
{
    static void Main(string[] args)
    {

        int size = getUserInput();
        Diamond userDiamond = new Diamond(size);
        userDiamond.Draw();

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static int getUserInput()
    {
        Console.Write("Enter the size of the diamond: ");
        int size = int.Parse(Console.ReadLine());
        return size;
    }

   
}

        