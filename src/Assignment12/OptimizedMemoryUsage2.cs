namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class OptimizedMemoryUsage2
{
    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    /// <param name="maxIteration">Maximum iterations</param>
    public void Allocate(int maxIteration = 1_000_000)
    {
        List<int[]> memAlloc = new List<int[]>();
        while (maxIteration >= 0)
        {
            // Added limit to the size of the list
            if (memAlloc.Count > 100)
            {
                // Remove the first element if the there are more than 100 arrays.
                memAlloc.RemoveAt(0);
            }

            memAlloc.Add(new int[1000]);
            maxIteration--;
        }
    }
}
