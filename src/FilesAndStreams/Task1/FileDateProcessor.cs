using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Task1;

/// <summary>
/// Contains method to create and read large files.
/// </summary>
internal class FileDateProcessor
{
    /// <summary>
    /// Writes a text string to a file using an intermediate memory buffer.
    /// </summary>
    /// <param name="path">The destination path of the file to create or overwrite.</param>
    /// <param name="data">The text data to encode and write into the file.</param>
    internal void WriteProcessedString(string path, string data)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            byte[] array = Encoding.UTF8.GetBytes(data);
            stream.Write(array, 0, array.Length);

            // Reset the position after writing.
            stream.Position = 0;

            using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
        }
    }

    /// <summary>
    /// Reads a file using a file stream to track total byte metrics.
    /// </summary>
    /// <param name="path">The target file path to open and read.</param>
    /// <returns>Time taken to read the file.</returns>
    internal long ReadWithFileStream(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found creating file ...");
            this.GenerateFile(path, 1_00_00_000);
            Console.WriteLine($"File {path} created.");
        }

        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[4 * 1024];
            int bytesRead;
            long totalBytesRead = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }

    /// <summary>
    /// Reads a file using a buffered stream to track total byte metrics.
    /// </summary>
    /// <param name="path">The target file path to open and read.</param>
    /// <returns>Time taken to read the file.</returns>
    internal long ReadWithBufferedStream(string path)
    {
        if (!File.Exists(path))
        {
            this.GenerateFile(path, 1_00_00_000);
        }

        Console.WriteLine($"Reading file with buffered stream {path}");
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 1024))
            {
                byte[] buffer = new byte[4 * 1024];
                int bytesRead;
                long totalBytesRead = 0;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
    }

    /// <summary>
    /// Process a text file containing numerical data to compute statistical temperature metrics.
    /// </summary>
    /// <param name="path">The target file path containing the dataset to process.</param>
    /// <returns>A task that represents the asynchronous operation, containing summary of the minimum, maximum, and average temperatures.</returns>
    internal string ProcessData(string path)
    {
        Console.WriteLine($"Processing {path}");

        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 1024))
            {
                byte[] buffer = new byte[4 * 1024];
                int charsRead;

                double maxTemperature = double.MinValue;
                double minTemperature = double.MaxValue;

                int count = 0;
                double sum = 0;

                string remainingText = string.Empty;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((charsRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string chunk = Encoding.UTF8.GetString(buffer, 0, charsRead);
                    remainingText += chunk;

                    string[] data = remainingText.Split("\n");

                    remainingText = data[data.Length - 1];

                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        if (double.TryParse(data[i], out double value))
                        {
                            if (value > maxTemperature)
                            {
                                maxTemperature = value;
                            }

                            if (value < minTemperature)
                            {
                                minTemperature = value;
                            }

                            sum += value;
                            count++;
                        }
                    }
                }

                stopwatch.Stop();

                Console.WriteLine($"Time taken to process {path}: {stopwatch.ElapsedMilliseconds} ms");
                return $"Minimum Temperature: {minTemperature}\nMaximum Temperature: {maxTemperature}\nAverage Temperature: {sum / count}\n";
            }
        }
    }

    /// <summary>
    /// Generates a randomized temperature entries.
    /// </summary>
    /// <param name="path">The target file path where the mock data will be written.</param>
    /// <param name="numberOfValues">The total count of randomized entries to generate.</param>
    internal void GenerateFile(string path, int numberOfValues)
    {
        Console.WriteLine($"Generating file {path} ...");
        using (StreamWriter writer = new StreamWriter(path))
        {
            Random random = new Random();

            for (int i = 0; i < numberOfValues; i++)
            {
                double value = (random.NextDouble() * 50) - 10;
                writer.Write(string.Concat(Enumerable.Repeat($"{value}\n", 6)));
            }
        }

        Console.WriteLine($"Generated file {path}.");
    }
}
