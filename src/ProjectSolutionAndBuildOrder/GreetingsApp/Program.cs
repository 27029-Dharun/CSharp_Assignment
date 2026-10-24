using DisplayApp;
using MathApp;

namespace GreetingsApp;

/// <summary>
/// Contains the application entry point.
/// </summary>
public class Program
{
    private static void Main()
    {
        Display.DisplayTitle("Welcome to the Calculator App");

        Display.DisplayResult("+", 10, 20, Calculator.Add(10, 20));
        Display.DisplayResult("-", 10, 20, Calculator.Subtract(10, 20));
        Display.DisplayResult("*", 10, 20, Calculator.Multiply(10, 20));
        Display.DisplayResult("/", 10, 20, Calculator.Divide(10, 20));

        Console.ReadKey();
    }
}