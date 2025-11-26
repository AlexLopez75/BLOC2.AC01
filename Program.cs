using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        const string MsgInputTemperature = "Input a decimal temperature: ";
        const string MsgInputConverion = "Input a number to convert temperature (1 - Celsius to Fahrenheit, 2 - Fahrenheit to Celsius, 3 - Celsius a Kelvin): ";
        const string MsgConvertion = "You chose number {0}, convertion: {1}";
        const string MsgIncorrect = "Input a number between 1 and 3.";
        const string MsgBadInput = "Input a natural number.";

        int convertionNumber;
        double temperature = 0;
        bool notValid = true;

        do
        {
            
            Console.Write(MsgInputTemperature);
            try
            {
                temperature = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                notValid = false;
            }
        } while (!notValid);
        
        do
        {
            Console.Write(MsgInputConverion);
            try
            {
                convertionNumber = Convert.ToInt32(Console.ReadLine());

                if (!NumberRange(convertionNumber))
                {
                    Console.WriteLine(MsgIncorrect);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                convertionNumber = 0;
            }
        } while (!NumberRange(convertionNumber));

        Console.WriteLine(MsgConvertion, convertionNumber, Convertion(convertionNumber, ref temperature));
    }
    public static bool NumberRange(int value)
    {
        const int MinRange = 1;
        const int MaxRange = 3;

        return value >= MinRange && value <= MaxRange;
    }

    public static string Convertion(int value, ref double temperature)
    {
        double result = 0;

        switch (value)
        {
            case 1:
                result = temperature * 9 / 5 + 32;
                break;
            case 2:
                result = (temperature -32) * 5 / 9;
                break;
            case 3:
                result = temperature + 273.15;
                break;
        }
        return result.ToString("F2");
    }
}
