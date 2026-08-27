using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the task1
/// </summary>
public class ArrayOperations
{
    private readonly Database _database;
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayOperations"/> class.
    /// </summary>
    /// <param name="database">Instance of the database</param>
    /// <param name="view">Instance of the view</param>
    public ArrayOperations(Database database, ConsoleView view)
    {
        this._database = database;
        this._view = view;
    }

    /// <summary>
    /// Gets the average price of the product
    /// </summary>
    public void HandleArrayOperations()
    {
        int[] integerArray = new int[10] { 1, 10, 6, -1, 5, 2, 8, 14, 12, 10 };
        int secondLargestNumber = integerArray.OrderByDescending(number => number).Skip(1).FirstOrDefault();

        this._view.PrintInfo($"Second largest number in the array: {secondLargestNumber}");

        int target = this._view.GetInteger("Enter the target number to find the unique pair: ");
        List<(int, int)> listOfTuple = integerArray
            .SelectMany((number1, index1) => integerArray.Select((number2, index2) => new { number1, number2, index1, index2 }))
            .Where(pair => pair.index1 < pair.index2 && pair.number1 + pair.number2 == target)
            .Select(pair => pair.number2 > pair.number1 ? (pair.number1, pair.number2) : (pair.number2, pair.number1))
            .Distinct().ToList();

        if (listOfTuple.Count <= 0)
        {
            this._view.PrintInfo($"No possible combination resulting to target: {target}");
        }

        this._view.PrintInfo("Unique combinations: ");
        foreach (var number in listOfTuple)
        {
            this._view.PrintInfo($"{number.Item1} {number.Item2}");
        }
    }
}
