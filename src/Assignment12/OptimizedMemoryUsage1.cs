namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class OptimizedMemoryUsage1 : IDisposable
{
    private List<int[]> _memAlloc = new List<int[]>();

    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    /// <param name="maxIteration">Maximum iterations</param>
    public void Allocate(int maxIteration = 1_00_000)
    {
        while (maxIteration >= 0)
        {
            // Added limit to the size of the list
            if (this._memAlloc.Count > 100)
            {
                // Remove the first element if the there are more than 100 arrays.
                this._memAlloc.RemoveAt(0);
            }

            this._memAlloc.Add(new int[1000]);
            maxIteration--;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this._memAlloc.Clear();
        GC.Collect();
    }
}
