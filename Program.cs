using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        const string MsgInput = "Input a natural number: ";
        const string MsgBadInput = "Input a natural number.";

        int number = 0;
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
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                isValid = false;
            }
        } while (!isValid);

        Console.Write($"{number} = ");
        NumberDescomposition(number);
        Console.WriteLine();
    }
    public static bool IsNatural(int number)
    {
        return number >= 0;
    }

    public static void NumberDescomposition(int number)
    {
        int exponent = 2;
        int counter = 0;
        int aux = number;

        while (aux > 1)
        {
            if (aux % exponent == 0)
            {
                counter++;
                aux /= exponent;
            }
            else
            {
                if (counter != 0)
                {
                    Console.Write($"{exponent}^{counter}*");
                }
                exponent++;
                counter = 0;
            }
        }
        Console.WriteLine($"{exponent}^{counter}");
    }
}
