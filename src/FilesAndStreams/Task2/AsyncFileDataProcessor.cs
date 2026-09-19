using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Task2;

/// <summary>
/// Read and write asynchronously.
/// </summary>
internal class AsyncFileDataProcessor
{
    /// <summary>
    /// Asynchronously generates a randomized temperature entries.
    /// </summary>
    /// <param name="path">The target file path where the mock data will be written.</param>
    /// <param name="numberOfLines">The total count of randomized entries to generate.</param>
    /// <returns>A task that represents the asynchronous file creation process.</returns>
    internal async Task GenerateFileAsync(string path, int numberOfLines)
    {
        Console.WriteLine($"Started creating {path}");

        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                Random random = Random.Shared;

                for (int i = 0; i < numberOfLines; i++)
                {
                    double value = (random.NextDouble() * 30) + 10;
                    writer.Write($"{DateTime.Now},Coimbatore,{value}\n");
                }

                await writer.FlushAsync();
            }
        }

        Console.WriteLine($"{path} file created.");
    }

    /// <summary>
    /// Asynchronously reads a file using a buffered stream to track total byte metrics.
    /// </summary>
    /// <param name="path">The target file path to open and read.</param>
    /// <returns>A task that represents the asynchronous reading process loop.</returns>
    internal async Task ReadWithBufferedStream(string path)
    {
        Console.WriteLine($"Reading {path} with optimized stream");

        int bufferSize = 1024 * 1024; // 1 MB

        using (FileStream stream = new FileStream(
            path,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            bufferSize))
        {
            byte[] buffer = new byte[bufferSize];
            long totalBytes = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                totalBytes += bytesRead;
            }

            stopwatch.Stop();
        }

        Console.WriteLine($"Completed reading {path}");
    }

    /// <summary>
    /// Process the data from the file asynchronously.
    /// </summary>
    /// <param name="inputPath">The input path of the file.</param>
    /// <param name="outputPath">The path to store the processed file.</param>
    /// <returns>A task that represents the asynchronous processing of data from the file.</returns>
    internal async Task ProcessAndWriteAsync(string inputPath, string outputPath)
    {
        Console.WriteLine($"Started processing {inputPath}");

        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 1024))
        {
            byte[] buffer = new byte[4 * 1024];
            int charsRead;

            double maxTemperature = double.MinValue;
            double minTemperature = double.MaxValue;
            int count = 0;
            double sum = 0;
            string remainingText = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();

            while ((charsRead = await bufferedStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string chunk = Encoding.UTF8.GetString(buffer, 0, charsRead);
                remainingText += chunk;

                string[] entry = remainingText.Split("\n");
                remainingText = entry[^1];

                for (int i = 0; i < entry.Length - 1; i++)
                {
                    string[] data = entry[i].Split(",");

                    if (data.Length > 2 && double.TryParse(data[2], out double value))
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
            Console.WriteLine($"Time taken to process {inputPath}: {stopwatch.ElapsedMilliseconds} ms");

            string report = this.CalculateStatistics(minTemperature, maxTemperature, sum, count);

            await this.WriteProcessedDataAsync(outputPath, report);
        }
    }

    /// <summary>
    /// Computes statistical metrics from numerical temperature inputs.
    /// </summary>
    private string CalculateStatistics(double min, double max, double sum, int count)
    {
        if (count == 0)
        {
            return "No valid numerical data found to process.\n";
        }

        double average = sum / count;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Minimum Temperature: {min}");
        sb.AppendLine($"Maximum Temperature: {max}");
        sb.AppendLine($"Average Temperature: {average}");

        return sb.ToString();
    }

    /// <summary>
    /// Writes the processed string data to a target file path using an intermediate MemoryStream.
    /// </summary>
    private async Task WriteProcessedDataAsync(string targetPath, string content)
    {
        byte[] dataToWrite = Encoding.UTF8.GetBytes(content);

        using (MemoryStream memStream = new MemoryStream())
        {
            await memStream.WriteAsync(dataToWrite, 0, dataToWrite.Length);

            // Reset position to read from the beginning of the memory stream
            memStream.Position = 0;

            // Stream the buffered data into the actual file destination
            using (FileStream fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                await memStream.CopyToAsync(fileStream);
            }
        }
    }
}
