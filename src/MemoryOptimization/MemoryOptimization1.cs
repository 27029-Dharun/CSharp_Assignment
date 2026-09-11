namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class MemoryOptimization1 : IDisposable
{
    private List<int[]> _memAlloc = new List<int[]>();

    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    /// <param name="maxIteration">Maximum iterations</param>
    public void Allocate(int maxIteration = 10_00_000)
    {
        // Should not use infinite loop to repeatedly allocate memory.
        while (maxIteration >= 0)
        {
            // Added limit to the size of the list.
            if (this._memAlloc.Count > 1_00_000)
            {
                return;
            }

            // Array with more than 21249 elements will become a large object.
            // Using large objects should be avoided, as the memory in large object heap will not be collected.
            this._memAlloc.Add(new int[1000]);
            maxIteration--;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this._memAlloc.Clear();
    }
}
