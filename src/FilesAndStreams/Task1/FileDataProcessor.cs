using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Task1;

/// <summary>
/// Contains method to create and read large files.
/// </summary>
internal class FileDataProcessor
{
    private const int LineCount = 2_50_00_000;

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
            this.GenerateFile(path, LineCount);
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
            this.GenerateFile(path, LineCount);
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
    /// <returns>Returns the time taken to write and process the data as string.</returns>
    internal string ProcessAndWrite(string inputPath, string outputPath)
    {
        Console.WriteLine($"Started processing {inputPath}");

        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 1024))
        {
            byte[] buffer = new byte[4 * 1024];
            int bytesRead;

            double maxTemperature = double.MinValue;
            double minTemperature = double.MaxValue;
            int count = 0;
            double sum = 0;
            string remainingText = string.Empty;

            Stopwatch stopwatch = Stopwatch.StartNew();

            while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                remainingText += chunk;

                string[] lines = remainingText.Split("\n");
                remainingText = lines[^1];

                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] data = lines[i].Split(",");

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
            string result = $"Time taken to process {inputPath}: {stopwatch.ElapsedMilliseconds} ms\n";

            string report = this.CalculateStatistics(minTemperature, maxTemperature, sum, count);

            stopwatch.Restart();
            this.WriteProcessedData(outputPath, report);
            stopwatch.Stop();

            result += $"Time taken to write the processed data in {outputPath}: {stopwatch.ElapsedMilliseconds} ms\n";

            return result;
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

            memStream.Position = 0;

            using (FileStream fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096))
            {
                memStream.CopyTo(fileStream);
            }
        }
    }
}
