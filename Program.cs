public class Program
{
    public static void Main()
    {
        const string MsgInputOne = "Input a natural number: ";
        const string MsgCorrect = "The number is between the range of valid numbers.";
        const string MsgIncorrect = "The number isn't between the range of valid numbers.";

        int number;

        do
        {
            Console.Write(MsgInputOne);
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (!NumberRange(number))
                {
                    Console.WriteLine(MsgIncorrect);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgIncorrect);
                number = 0;
            }
        } while (!NumberRange(number));

        Console.WriteLine(MsgCorrect);
    }

    public static bool NumberRange(int value)
    {
        const int MinRange = 10;
        const int MaxRange = 50;

        return value >= MinRange && value <= MaxRange;
    }
}
