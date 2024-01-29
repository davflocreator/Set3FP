using System;

//Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.

class Program
{
    static void Main()
    {
        string text;
        Console.WriteLine("Introduceti un vector de numere, de forma x y z:");
        text = Console.ReadLine();
        string[] numbers = text.Split(' ');
        int[] sir = new int[numbers.Length];
        int suma = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sir[i] = int.Parse(numbers[i]);
            suma += sir[i];
        }
        Console.WriteLine("Suma elementelor din sir este {0}", suma);
    }
}