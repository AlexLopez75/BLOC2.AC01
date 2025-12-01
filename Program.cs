using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        const int MinRange = 1;
        const int MaxRange = 3;
        const string MsgInputTemperature = "Input a decimal temperature: ";
        const string MsgInputConverion = "Input a number to convert temperature (1 - Celsius to Fahrenheit, 2 - Fahrenheit to Celsius, 3 - Celsius a Kelvin). You have {0} attempts left: ";
        const string MsgConvertion = "You chose {0}, convertion: {1}.";
        const string MsgIncorrect = "Input a number between 1 and 3. You have {0} attempts left.";
        const string OutOfAttempts = "You are out of attempts.";
        const string MsgBadInput = "Input a natural number.";

        int convertionNumber, attempts = 3;
        double temperature = 0;
        bool isValid = true;

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
                isValid = false;
            }
        } while (!isValid);

        do
        {
            Console.Write(MsgInputConverion, attempts);
            try
            {
                convertionNumber = Convert.ToInt32(Console.ReadLine());

                if (!NumberRange(convertionNumber, MaxRange, MinRange))
                {
                    attempts--;
                    Console.WriteLine(MsgIncorrect, attempts);
                    if (attempts == 0)
                    {
                        Console.WriteLine(OutOfAttempts);
                    }
                }
            }
            catch (FormatException)
            {
                attempts--;
                Console.WriteLine(MsgBadInput);
                convertionNumber = 0;
            }
        } while (!NumberRange(convertionNumber, MaxRange, MinRange) && attempts > 0);

        switch (convertionNumber)
        {
            case 1:
                Console.WriteLine(MsgConvertion, convertionNumber, FarenheitConvertion(ref temperature));
                break;
            case 2:
                Console.WriteLine(MsgConvertion, convertionNumber,CelsiusConvertion(ref temperature));
                break;
            case 3:
                Console.WriteLine(MsgConvertion, convertionNumber, KelvinConvertion(ref temperature));
                break;
        }
    }
    public static bool NumberRange(int value, int maxRange, int minRange)
    {
        return value >= minRange && value <= maxRange;
    }
    public static string FarenheitConvertion(ref double temperature)
    {
        double result = 0;

        result = temperature * 9 / 5 + 32;

        return result.ToString("F2");
    }
    public static string CelsiusConvertion(ref double temperature)
    {
        double result = 0;

        result = (temperature - 32) * 5 / 9;

        return result.ToString("F2");
    }

    public static string KelvinConvertion(ref double temperature)
    {
        double result = 0;

        result = temperature + 273.15;

        return result.ToString("F2");
    }
}
