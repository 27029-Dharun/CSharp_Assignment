namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the implementation of the lambda expression
/// </summary>
internal class LambdaExpressions
{
    /// <summary>
    /// Creates, filters and selects the list.
    /// </summary>
    public void ManipulateList()
    {
        List<int> integers = new List<int> { 10, 30, 20, 40, 50, 60 };

        var evenNumbers = integers.Where((int number) => number % 2 == 0);
        Console.WriteLine(string.Join(", ", evenNumbers));

        var squaredNumbers = integers.Select((int number) => number * 2);
        Console.WriteLine(string.Join(", ", squaredNumbers));
    }
}
