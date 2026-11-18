using System.Collections.ObjectModel;
using Collections.IO;

namespace Collections.Tasks;

/// <summary>
/// Contains implementation of concrete types.
/// </summary>
public static class CollectionAbstractions
{
    /// <summary>
    /// Computes the sum of integers in the collection.
    /// </summary>
    /// <param name="numbers">A collection that contains integer.</param>
    /// <returns>The sum of all the integers present in the collection.</returns>
    public static int SumOfElements(IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }

    /// <summary>
    /// Generates the dictionary with key-value pair
    /// </summary>
    /// <returns>A read only dictionary</returns>
    public static IReadOnlyDictionary<string, int> GenerateDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "Apple", 10 },
            { "Mango", 20 },
            { "Orange", 30 },
        };

        return new ReadOnlyDictionary<string, int>(dictionary);
    }

    /// <summary>
    /// Tries to modify the given dictionary by casting it to IDictionary.
    /// The dictionary is printed after every attempt.
    /// </summary>
    /// <param name="dictionary">The dictionary returned by GenerateDictionary().</param>
    public static void TryModifyDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        try
        {
            IDictionary<string, int> writable = (IDictionary<string, int>)dictionary;
            writable.Add("Banana", 40);
            ConsoleIO.PrintInfo("Dictionary was modified.");
        }
        catch (NotSupportedException)
        {
            ConsoleIO.PrintInfo("Modification failed: the dictionary is read-only.");
        }
        catch (Exception ex)
        {
            ConsoleIO.PrintInfo("Modification failed" + ex.Message);
        }

        PrintDictionary(dictionary);
    }

    /// <summary>
    /// Prints the dictionary elements.
    /// </summary>
    /// <param name="dictionary">The dictionary to be printed</param>
    public static void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        foreach (var pair in dictionary)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        }
    }
}
