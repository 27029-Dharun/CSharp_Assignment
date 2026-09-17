using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the array operations
/// </summary>
public class ArrayOperations
{
    /// <summary>
    /// Handles the array operations
    /// </summary>
    public void HandleArrayOperations()
    {
        // Initialize an array.
        int[] numbers = new int[10] { 1, 10, 6, -1, 5, 2, 8, 14, 12, 10 };
        ConsoleIO.PrintInfo($"The array elements are: {string.Join(", ", numbers)}");

        // Find and display the second largest element in the array.
        try
        {
            int secondLargestNumber = numbers.OrderByDescending(number => number).Skip(1).FirstOrDefault();
            ConsoleIO.PrintInfo($"Second largest number in the array: {secondLargestNumber}");
        }
        catch (Exception)
        {
            ConsoleIO.PrintInfo("No second highest number in the list.");
        }

        // Gets the target input from the user
        int target = ConsoleIO.GetInteger("Enter the target number to find the unique pair: ");

        // Find all unique pair that sums up into the unique pair.
        List<(int, int)> uniquePairs =
            numbers
                .SelectMany((first, index1) => numbers.Select((int second, int index2) => new { number1= first, number2=second, index1, index2 }))
                .Where(pair => pair.index1 < pair.index2 && pair.number1 + pair.number2 == target)
                .Select(pair => pair.number2 > pair.number1 ? (pair.number1, pair.number2) : (pair.number2, pair.number1))
                .Distinct()
                .ToList();

        if (uniquePairs.Count <= 0)
        {
            ConsoleIO.PrintInfo($"No possible combination resulting to target: {target}");
            return;
        }

        ConsoleIO.PrintInfo("Unique combinations: ");
        foreach (var number in uniquePairs)
        {
            ConsoleIO.PrintInfo($"{number.Item1} {number.Item2}");
        }
    }
}
