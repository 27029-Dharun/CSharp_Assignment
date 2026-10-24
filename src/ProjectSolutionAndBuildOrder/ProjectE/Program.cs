using DisplayApp;

namespace ProjectE;

/// <summary>
/// Contains the main method and entry point.
/// </summary>
public class Program
{
    private static void Main()
    {
        Display.DisplayTitle("Welcome to the distance converter app");
        Display.DisplayDistanceInMiles(20, 20 * 0.621);

        Console.ReadKey();
    }
}