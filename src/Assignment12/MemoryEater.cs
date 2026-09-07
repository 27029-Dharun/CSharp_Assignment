namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class MemoryEater
{
    private List<int[]> _memAlloc = new List<int[]>();

    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    public void Allocate()
    {
        while (true)
        {
            // Added limit to the size of the list
            if (this._memAlloc.Count > 100)
            {
                // Remove the first element if the there are more than 100 arrays.
                this._memAlloc.RemoveAt(0);
            }

            this._memAlloc.Add(new int[1000]);
        }
    }
}
