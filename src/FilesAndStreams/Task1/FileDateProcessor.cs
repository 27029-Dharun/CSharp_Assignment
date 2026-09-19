using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Task1;

/// <summary>
/// Contains method to create and read large files.
/// </summary>
internal class FileDateProcessor
{
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
                double value = (random.NextDouble() * 30) + 10;
                writer.Write($"{DateTime.Now},Coimbatore,{value}\n");
            }
        }

        Console.WriteLine($"Generated file {path}.");
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
            this.GenerateFile(path, 2_50_00_000);
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
            this.GenerateFile(path, 2_50_00_000);
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
    /// Process the data from the file synchronously.
    /// </summary>
    /// <param name="inputPath">The input path of the file.</param>
    /// <param name="outputPath">The path to store the processed file.</param>
    internal void ProcessAndWrite(string inputPath, string outputPath)
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

            while ((charsRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
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

            this.WriteProcessedData(outputPath, report);
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
    private void WriteProcessedData(string targetPath, string content)
    {
        byte[] dataToWrite = Encoding.UTF8.GetBytes(content);

        using (MemoryStream memStream = new MemoryStream())
        {
            memStream.Write(dataToWrite, 0, dataToWrite.Length);

            // Reset position to read from the beginning of the memory stream
            memStream.Position = 0;

            // Stream the buffered data into the actual file destination
            using (FileStream fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                memStream.CopyTo(fileStream);
            }
        }
    }
}
