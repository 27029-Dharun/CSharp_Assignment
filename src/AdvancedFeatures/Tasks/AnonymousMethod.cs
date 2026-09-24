using AdvancedFeatures.IO;

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

        ConsoleIO.PrintInfo($"Array before storing: {string.Join(", ", integers)}\n");

        Array.Sort(integers, delegate(int first, int second)
        {
            return first.CompareTo(second);
        });

        ConsoleIO.PrintInfo($"Array after sorting: {string.Join(", ", integers)}\n");
    }
}