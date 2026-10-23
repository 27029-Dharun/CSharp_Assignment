namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class MemoryEater
{
    private const int MaxIteration = 3_000;
    private List<int[]> _memAlloc = new List<int[]>();

    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    public void Allocate()
    {
        for (int i = 0; i < MaxIteration; i++)
        {
            this._memAlloc.Add(new int[1000]);

            // Assume memAlloc variable is used within the loop.
            Thread.Sleep(10);
        }
    }
}