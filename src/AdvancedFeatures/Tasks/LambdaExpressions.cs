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

        var evenNumbers = integers.Where(number => number % 2 == 0);
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

        var squaredNumbers = integers.Select(number => number * number);
        Console.WriteLine("Squared results: " + string.Join(", ", squaredNumbers));
    }
}