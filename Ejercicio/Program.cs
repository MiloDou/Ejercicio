using System;
using System.Collections.Generic;
using System.Linq;

public class Calculator
{
    static List<double> numbers = new List<double>();

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
                        EnterNewNumbers(numbers);
                        break;
                    case 2:
                        Console.WriteLine($"Mean: {CalculateMean(numbers)}");
                        break;
                    case 3:
                        Console.WriteLine($"Median: {CalculateMedian(numbers)}");
                        break;
                    case 4:
                        Console.WriteLine($"Mode: {CalculateMode(numbers)}");
                        break;
                    case 5:
                        Console.WriteLine($"Standard Deviation: {CalculateStandardDeviation(numbers)}");
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

    static void EnterNewNumbers(List<double> numbers)
    {
        Console.Clear();
        try
        {
            Console.WriteLine("---------------------------");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("       NEW NUMBERS");
            Console.ResetColor();
            Console.WriteLine("-------------------------\n");
            numbers.Clear();
            Console.Write("Choose the limit of numbers: ");
            int LimitNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= LimitNumber; i++)
            {
                Console.Write($"Write number {i} : ");
                double number = Convert.ToDouble(Console.ReadLine());
                numbers.Add(number);
            }
        }
        catch (FormatException ErrorMessage)
        {
            Console.WriteLine("Invalid format");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMessage);
            Console.ResetColor();
        }
        catch (OverflowException ErrorMessage1)
        {
            Console.WriteLine("Overflow error");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMessage1);
            Console.ResetColor();
        }
        Console.ReadKey();
    }

    static double CalculateMean(List<double> numbers)
    {
        double sum = numbers.Sum();
        double mean = sum / numbers.Count;
        return mean;
    }

    static double CalculateMedian(List<double> numbers)
    {
        numbers.Sort();
        int count = numbers.Count;
        if (count % 2 == 0)
        {
            return (numbers[count / 2 - 1] + numbers[count / 2]) / 2;
        }
        else
        {
            return numbers[count / 2];
        }
    }

    static double CalculateMode(List<double> numbers)
    {
        var groups = numbers.GroupBy(v => v).OrderByDescending(g => g.Count());
        var mostFrequentGroup = groups.First();
        if (mostFrequentGroup.Count() == 1)
        {
            Console.WriteLine("No mode found");
            return double.NaN;
        }
        else
        {
            return mostFrequentGroup.Key;
        }
    }

    static double CalculateStandardDeviation(List<double> numbers)
    {
        double mean = CalculateMean(numbers);
        double sumOfSquaresOfDifferences = numbers.Select(val => (val - mean) * (val - mean)).Sum();
        double standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / numbers.Count);
        return standardDeviation;
    }

    static void RequestNewNumbers()
    {
        EnterNewNumbers(numbers);
    }

    static void ExitProgram()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nCiao Bella User...");
        Console.ResetColor();
    }
}
