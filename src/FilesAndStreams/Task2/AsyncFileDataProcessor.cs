using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Task2;

/// <summary>
/// Read and write asynchronously.
/// </summary>
internal class AsyncFileDataProcessor
{
    /// <summary>
    /// Asynchronously writes a text string to a file using an intermediate memory buffer.
    /// </summary>
    /// <param name="path">The destination path of the file to create or overwrite.</param>
    /// <param name="data">The text data to encode and write into the file.</param>
    /// <returns>A task that represents the asynchronous write and copy operations.</returns>
    internal async Task WriteProcessedString(string path, string data)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            byte[] array = Encoding.UTF8.GetBytes(data);
            await stream.WriteAsync(array, 0, array.Length);

            // Reset the position after writing to read from beginning.
            stream.Position = 0;

            using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fileStream);
        }
    }

    /// <summary>
    /// Asynchronously reads a file using a buffered stream to track total byte metrics.
    /// </summary>
    /// <param name="path">The target file path to open and read.</param>
    /// <returns>A task that represents the asynchronous reading process loop.</returns>
    internal async Task ReadWithBufferedStream(string path)
    {
        Console.WriteLine($"Reading {path} with buffered stream");
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 1024))
            {
                byte[] buffer = new byte[4 * 1024];
                int bytesRead;
                int totalBytes = 0;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while ((bytesRead = await bufferedStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytes += bytesRead;
                }
            }
        }

        Console.WriteLine($"Completed reading {path}");
    }

    /// <summary>
    /// Asynchronously processes a text file containing numerical data to compute statistical temperature metrics.
    /// </summary>
    /// <param name="path">The target file path containing the dataset to process.</param>
    /// <returns>A task that represents the asynchronous operation, containing summary of the minimum, maximum, and average temperatures.</returns>
    internal async Task<string> ProcessDataAsync(string path)
    {
        Console.WriteLine($"Started processing {path}");

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
                while ((charsRead = await bufferedStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string chunk = Encoding.UTF8.GetString(buffer, 0, charsRead);
                    remainingText += chunk;

                    string[] data = remainingText.Split("\n");

                    remainingText = data[^1];

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
    /// Asynchronously generates a randomized temperature entries.
    /// </summary>
    /// <param name="path">The target file path where the mock data will be written.</param>
    /// <param name="numberOfValues">The total count of randomized entries to generate.</param>
    /// <returns>A task that represents the asynchronous file creation process.</returns>
    internal async Task GenerateFileAsync(string path, int numberOfValues)
    {
        Console.WriteLine($"Started creating {path}");
        using (StreamWriter writer = new StreamWriter(path))
        {
            Random random = new Random();

            for (int i = 0; i < numberOfValues; i++)
            {
                double value = (random.NextDouble() * 50) - 10;

                await writer.WriteLineAsync(value.ToString());
            }
        }

        Console.WriteLine($"{path} file created.");
    }
}
