using Collections.IO;

namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the implementation of the lambda expression.
/// </summary>
internal class LambdaExpressions
{
    /// <summary>
    /// Creates, filters and selects the list.
    /// </summary>
    internal void ManipulateList()
    {
        List<int> integers = new List<int> { 11, 31, 20, 40, 51, 60 };

        ConsoleIO.PrintInfo($"Original array: {string.Join(", ", integers)}\n");

        var evenNumbers = integers.Where(number => number % 2 == 0);
        ConsoleIO.PrintInfo($"Even numbers: {string.Join(", ", evenNumbers)}\n");

        var squaredNumbers = integers.Select(number => number * number);
        ConsoleIO.PrintInfo($"Squared results: {string.Join(", ", squaredNumbers)}\n");
    }
}