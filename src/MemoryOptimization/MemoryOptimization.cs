namespace Assignment12;

/// <summary>
/// Contains logic to allocate memory
/// </summary>
internal class MemoryOptimization
{
    private const int ArraySize = 1000;
    private const int DefaultIteration = 3_000;

    /// <summary>
    /// Allocates memory and adds it to a list
    /// </summary>
    /// <param name="maxIteration">Maximum iterations</param>
    public void Allocate(int maxIteration = DefaultIteration)
    {
        int[] buffer = new int[ArraySize];

        // Should not use infinite loop to repeatedly allocate memory.
        for (int i = 0; i < maxIteration; i++)
        {
            buffer.AsSpan().Fill(i);

            Thread.Sleep(10);
        }
    }
}
