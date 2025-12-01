using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        const string MsgInput = "Input a natural number: ";
        const string MsgBadInput = "Input a natural number.";
        const string MsgDecomposition = "{0} = 2^{1}*3^{2}*5^{3}*7^{4}*11^{5}";

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

        NumberDescomposition(number);
        Console.WriteLine(MsgDecomposition, number);
    }
    public static bool IsNatural(int number)
    {
        return number >= 0;
    }

    public static void NumberDescomposition(int number)
    {
        int i = 0;
        int aux = number;

        do
        {
            i++;
            if (aux % i == 0)
            {
                aux /= i;
                i = 0;
            }
        } while (aux > 0); 
    }
}
