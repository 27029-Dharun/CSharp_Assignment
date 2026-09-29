namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class MemoryOptimization
{
    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    /// <param name="maxIteration">Maximum iterations</param>
    public void Allocate(int maxIteration = 10_00_000)
    {
        // Should declare the array in the correct place, the list is only accessed within the method so better to keep it inside the method.
        List<int[]> memAlloc = new List<int[]>();

        // Should not use infinite loop to repeatedly allocate memory.
        while (maxIteration >= 0)
        {
            // Added limit to the size of the list.
            if (memAlloc.Count > 1_00_000)
            {
                return;
            }

            // Array with more than 21249 elements will become a large object.
            // Using large objects should be avoided, as the memory in large object heap will not be collected.
            memAlloc.Add(new int[1000]);
            maxIteration--;
        }
    }
}
