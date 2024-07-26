using System;

public class ArchaicCalculator
{
    static double number1 = 0;
    static double number2 = 0;
    static double number3 = 0;
    static double number4 = 0;
    static double number5 = 0;
    static double result = 0;

    public static void Main()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                ShowMenu();
                int option1 = Convert.ToInt32(Console.ReadLine());
                switch (option1)
                {
                    case 1:
                        EnterNewNumbers();
                        break;

                    case 2:
                        result = CalculateMean(number1, number2, number3, number4, number5);
                        Console.WriteLine("\nThe mean is: " + result);
                        break;

                    case 3:
                        double median = CalculateMedian(number1, number2, number3, number4, number5);
                        Console.WriteLine("\nThe median is: " + median);
                        break;

                    case 4:
                        double mode = CalculateMode(number1, number2, number3, number4, number5);
                        Console.WriteLine("\nThe mode is: " + mode);
                        break;

                    case 5:
                        double standardDeviation = CalculateStandardDeviation(number1, number2, number3, number4, number5);
                        Console.WriteLine("\nThe standard deviation is: " + standardDeviation);
                        break;

                    case 6:
                        RequestNewNumbers();
                        break;

                    case 7:
                        ExitProgram();
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Invalid format\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press Enter to continue");
                Console.ResetColor();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Overflow\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press Enter to continue");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("        CALCULATOR");
        Console.ResetColor();
        Console.WriteLine("-------------------------\n");
        Console.WriteLine("1. Enter numbers");
        Console.WriteLine("2. Calculate mean");
        Console.WriteLine("3. Calculate median");
        Console.WriteLine("4. Calculate mode");
        Console.WriteLine("5. Calculate standard deviation");
        Console.WriteLine("6. Request new numbers");
        Console.WriteLine("7. Exit");
        Console.Write("\nChoose an option: ");
    }

    static void EnterNewNumbers()
    {
        Console.Clear();
        try
        {
            Console.WriteLine("--------------------------");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("       NEW NUMBERS");
            Console.ResetColor();
            Console.WriteLine("-------------------------\n");
            Console.Write("Write first number: ");
            number1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Write second number: ");
            number2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Write third number: ");
            number3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Write fourth number: ");
            number4 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Write fifth number: ");
            number5 = Convert.ToDouble(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow error");
        }
        Console.ReadKey();
    }

    static double CalculateMean(double a, double b, double c, double d, double e)
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("       CALCULATE MEAN");
        Console.ResetColor();
        Console.WriteLine("-------------------------\n");
        double sum = a + b + c + d + e;
        double count = 5;
        return sum / count;
    }

    static double CalculateMedian(double a, double b, double c, double d, double e)
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("       CALCULATE MEDIAN");
        Console.ResetColor();
        Console.WriteLine("-------------------------\n");

        // Encontrar el valor mediano
        if ((a > b) == (a < c) && (a > c) == (a < d) && (a > d) == (a < e))
            return a;
        else if ((b > a) == (b < c) && (b > c) == (b < d) && (b > d) == (b < e))
            return b;
        else if ((c > a) == (c < b) && (c > b) == (c < d) && (c > d) == (c < e))
            return c;
        else if ((d > a) == (d < b) && (d > b) == (d < c) && (d > c) == (d < e))
            return d;
        else
            return e;
    }

    static double CalculateMode(double a, double b, double c, double d, double e)
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("       CALCULATE MODE");
        Console.ResetColor();
        Console.WriteLine("-------------------------\n");

        double[] numbers = { a, b, c, d, e };
        var groups = numbers.GroupBy(v => v).OrderByDescending(g => g.Count());
        var mostFrequentGroup = groups.First();
        if (mostFrequentGroup.Count() == 1)
        {
            Console.WriteLine("No found Mode");
            return double.NaN; 
        }
        else
        {
            return mostFrequentGroup.Key;
        }
    }
    static double CalculateStandardDeviation(double a, double b, double c, double d, double e)
    {
        Console.WriteLine("-----------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("   CALCULATE STANDARD DEVIATION");
        Console.ResetColor();
        Console.WriteLine("-----------------------------------\n");

        double mean = CalculateMean(a, b, c, d, e);
        double variance = ((Math.Pow(a - mean, 2) + Math.Pow(b - mean, 2) + Math.Pow(c - mean, 2) + Math.Pow(d - mean, 2) + Math.Pow(e - mean, 2)) / 5);
        return Math.Sqrt(variance);
    }

    static void RequestNewNumbers()
    {
        EnterNewNumbers();
    }

    static void ExitProgram()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nCiao Bella User...");
        Console.ResetColor();
    }
}
