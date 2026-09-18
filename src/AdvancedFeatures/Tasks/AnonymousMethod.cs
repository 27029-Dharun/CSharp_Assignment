namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the implementation of the anonymous method.
/// </summary>
internal class AnonymousMethod
{
    /// <summary>
    /// Sorts the array with a anonymous method.
    /// </summary>
    internal void SortArray()
    {
        int[] integers = { 10, 30, 20, 40, 99, 88, 100, 55, 110 };

        Array.Sort(integers, delegate(int first, int second)
        {
            return first.CompareTo(second);
        });

        Console.WriteLine(string.Join(", ", integers));
    }
}
