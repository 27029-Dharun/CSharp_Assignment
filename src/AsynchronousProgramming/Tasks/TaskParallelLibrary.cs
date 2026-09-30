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
    public void Run()
    {
        int[] integerArray = new int[10000];

        for (int i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = i + 1;
        }

        long time = this.SequentialSquaring(integerArray);

        long timeForParallel = this.ParallelSquaring(integerArray);

        Console.WriteLine($"Time taken for sequential squaring: {time} ms");
        Console.WriteLine($"Time taken for parallel squaring: {timeForParallel} ms");
    }

    private long SequentialSquaring(int[] integerArray)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        foreach (var integer in integerArray)
        {
            int res = integer * integer;
            Console.WriteLine(res);
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    private long ParallelSquaring(int[] integerArray)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Parallel.ForEach(integerArray, (i) =>
        {
            i = i * i;
            Console.WriteLine(i);
        });

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
