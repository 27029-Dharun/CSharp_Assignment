using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the array operations
/// </summary>
public class ArrayOperations
{
    /// <summary>
    /// Handles the array operations.
    /// </summary>
    public void HandleArrayOperations()
    {
        int[] integerArray = new int[10] { 1, 10, 6, -1, 5, 2, 8, 14, 12, 10 };
        ConsoleIO.PrintInfo($"The array elements are: {string.Join(", ", integerArray)}");

        int secondLargestNumber = integerArray.OrderByDescending(number => number).Skip(1).FirstOrDefault();

        ConsoleIO.PrintInfo($"Second largest number in the array: {secondLargestNumber}");

        int target = ConsoleIO.GetInteger("Enter the target number to find the unique pair: ");
        List<(int, int)> listOfTuple = integerArray
            .SelectMany((number1, index1) => integerArray.Select((number2, index2) => new { number1, number2, index1, index2 }))
            .Where(pair => pair.index1 < pair.index2 && pair.number1 + pair.number2 == target)
            .Select(pair => pair.number2 > pair.number1 ? (pair.number1, pair.number2) : (pair.number2, pair.number1))
            .Distinct().ToList();

        if (listOfTuple.Count <= 0)
        {
            ConsoleIO.PrintInfo($"No possible combination resulting to target: {target}");
            return;
        }

        ConsoleIO.PrintInfo("Unique combinations: ");
        foreach (var number in listOfTuple)
        {
            ConsoleIO.PrintInfo($"{number.Item1} {number.Item2}");
        }
    }
}
