using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        const string MsgInputHours = "Input the hours you have parked: ";
        const string MsgInputMinutes = "Input the minutes you have parked: ";
        const string MsgBadInput = "Input a natural number.";
        const string MsgPayPrice = "You have to pay a total of: {0} €";

        double hours = 0, minutes = 0;
        bool isValid = true;

        do
        {
            
            Console.Write(MsgInputHours);
            try
            {
                hours = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                isValid = false;
            }
        } while (!isValid);
        
        do
        {

            Console.Write(MsgInputMinutes);
            try
            {
                minutes = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(MsgBadInput);
                isValid = false;
            }
        } while (!isValid);

        Console.WriteLine(MsgPayPrice, PriceStation(ref hours, ref minutes));
    }
    public static string PriceStation(ref double hours, ref double minutes)
    {
        const int FirstHourTax = 1;
        const int IntervalTaxMin = 2;
        const int IntervalTaxMax = 5;
        const int FinalTax = 6;

        double price = 0;

        hours += minutes / 60;

        if (hours >= FirstHourTax)
        {
            price = hours * 3.50;
        }
        if (hours >= IntervalTaxMin && hours <= IntervalTaxMax)
        {
            price = hours * 2.00;
        }
        if (hours >= FinalTax)
        {
            price = hours * 1.50;
        }
        return price.ToString("F2");
    }
}
