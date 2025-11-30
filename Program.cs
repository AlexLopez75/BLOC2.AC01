using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        const string MsgInput = "Input a natrual number: ";
        const string MsgBadInput = "Error: your input isn't natural number.";
        const string MsgSum = "Sum of all even digits: {0}";
        const string MsgMult = "Multiplication of all odd digits: {0}";
        const string MsgMinMax = "Major digit: {0}\nMinor digit {1}";

        int number = 0;
        int sumEvens = 0;
        int multOdds = 1;
        int majorDigit = 0;
        int minorDigit = 9;
        bool isValid = true;

        do
        {
            Console.Write(MsgInput);
            try
            {
                number = Int32.Parse(Console.ReadLine());
                IsNatural(number);
                if (!IsNatural(number))
                {
                    Console.WriteLine(MsgBadInput);
                    isValid = false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                isValid = false;
            }
        } while (!isValid);

        NumberSums(number, ref sumEvens, ref multOdds, ref majorDigit, ref minorDigit);
        Console.WriteLine(MsgSum, sumEvens);
        Console.WriteLine(MsgMult, multOdds);
        Console.WriteLine(MsgMinMax, majorDigit, minorDigit);
    }
    public static bool IsNatural(int number)
    {
        return number >= 0;
    }

    public static void NumberSums(int number, ref int sumEvens, ref int multOdds, ref int majorDigit, ref int minorDigit)
    {
        int counter = 0;
        string input = number.ToString();

        foreach (char c in input)
        {
            counter++;
            int digit = c - '0'; //Converts c to int.

            if (digit > majorDigit)
            {
                majorDigit = digit;
            }
            if (digit < minorDigit)
            {
                minorDigit = digit;
            }

            if (counter % 2 == 0)
            {
                sumEvens += digit;
            }
            else
            {
                multOdds *= digit;
            }
        }
    }
}
