public class Program
{
    public static void Main()
    {
        const string MsgInputOne = "Input a natural number: ";
        const string MsgCorrect = "The number is between the range of valid numbers.";
        const string MsgIncorrect = "The number isn't between the range of valid numbers.";
        const string MsgBadInput = "Input a natural number.";
        const int MinRange = 10;
        const int MaxRange = 50;

        int number;

        do
        {
            Console.Write(MsgInputOne);
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (!NumberRange(number, MinRange, MaxRange))
                {
                    Console.WriteLine(MsgIncorrect);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                number = 0;
            }
        } while (!NumberRange(number, MinRange, MaxRange));

        Console.WriteLine(MsgCorrect);
    }

    public static bool NumberRange( int value, int MinRange, int MaxRange)
    {
        return value >= MinRange && value <= MaxRange;
    }
}
