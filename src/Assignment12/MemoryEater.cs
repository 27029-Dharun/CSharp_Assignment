namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class MemoryEater
{
    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    public void Allocate()
    {
        while (true)
        {
            List<int[]> memAlloc = new List<int[]>();
            memAlloc.Add(new int[1000]);
        }
    }
}
