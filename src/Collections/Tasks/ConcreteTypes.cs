namespace Collections.Tasks;

/// <summary>
/// Contains implementation of concrete types.
/// </summary>
public class ConcreteTypes
{
    /// <summary>
    /// Computes the sum of integers in the collection.
    /// </summary>
    /// <param name="numbers">A collection that contains integer.</param>
    /// <returns>The sum of all the integers present in the collection.</returns>
    public int SumOfElements(IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }

    /// <summary>
    /// Generates the dictionary with key-value pair
    /// </summary>
    /// <returns>A read only dictionary</returns>
    public IReadOnlyDictionary<string, int> GenerateDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "Apple", 10 },
            { "Mango", 20 },
            { "Orange", 30 },
        };

        return dictionary;
    }

    /// <summary>
    /// Prints the dictionary elements.
    /// </summary>
    /// <param name="dictionary">The dictionary to be printed</param>
    public void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        foreach (var pair in dictionary)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        }
    }
 }
