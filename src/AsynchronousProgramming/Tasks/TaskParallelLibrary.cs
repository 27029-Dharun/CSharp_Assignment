using System.Diagnostics;

namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the implementation of task parallel library.
/// </summary>
internal class TaskParallelLibrary
{
    /// <summary>
    /// Squares the element in the library.
    /// </summary>
    public void CalculateSquare()
    {
        int[] integerArray = new int[10_000];
        int[] result = new int[10_000];

        for (int i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = i + 1;
        }

        long timeForSequentialSquaring = this.SequentialSquaring(integerArray, result);

        foreach (var value in result)
        {
            Console.WriteLine(value);
        }

        long timeForParallelSquaring = this.ParallelSquaring(integerArray, result);

        foreach (var value in result)
        {
            Console.WriteLine(value);
        }

        Console.WriteLine($"Time taken for sequential squaring: {timeForSequentialSquaring} ms");
        Console.WriteLine($"Time taken for parallel squaring: {timeForParallelSquaring} ms");
    }

    private long SequentialSquaring(int[] integerArray, int[] result)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int i = 0;

        foreach (var integer in integerArray)
        {
            result[i++] = integer * integer;
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    private long ParallelSquaring(int[] integerArray, int[] result)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int i = 0;

        Parallel.ForEach(integerArray, (value) =>
        {
            result[i] = value * value;
        });

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
