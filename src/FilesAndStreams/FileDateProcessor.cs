using System.Diagnostics;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Contains method to create and read large files.
/// </summary>
internal class FileDateProcessor
{
    /// <summary>
    /// Reads the file
    /// </summary>
    internal void Run()
    {
        Console.WriteLine("Reading with FileStream");
        long timeTakenWithFileStream = this.ReadWithFileStream("file.txt");
        Console.WriteLine("Time taken to read with file stream: " + timeTakenWithFileStream);

        Console.WriteLine("Reading with Buffered Stream");
        long timeTakenWithBufferedStream = this.ReadWithBufferedStream("file.txt");
        Console.WriteLine("Time taken to read with buffered stream: " + timeTakenWithBufferedStream);

        Console.WriteLine($"Buffer stream is {timeTakenWithFileStream - timeTakenWithBufferedStream} ms faster");

        string data = this.ProcessData("file.txt");

        this.WriteProcessedString("data.txt", data);
    }

    private void WriteProcessedString(string path, string data)
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

    private long ReadWithFileStream(string path)
    {
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

    private long ReadWithBufferedStream(string path)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(stream, 32 * 1024))
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

    private string ProcessData(string path)
    {
        Console.WriteLine("Calculating Maximum Temperature And Minimum Temperature");

        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                char[] buffer = new char[4 * 1024];
                int charsRead;

                double maxTemperature = double.MinValue;
                double minTemperature = double.MaxValue;

                int count = 0;
                double sum = 0;

                string remainingText = string.Empty;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Append only the portion read
                    string chunk = new string(buffer, 0, charsRead);
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

                Console.WriteLine("The time taken to calculate : " + stopwatch.ElapsedMilliseconds);
                return $"Minimum Temperature: {minTemperature}\nMaximum Temperature: {maxTemperature}\nAverage Temperature: {sum / count}\n";
            }
        }
    }

    private void GenerateFile(string path, int numberOfValues)
    {
        using StreamWriter writer = new StreamWriter(path);

        Random random = new ();

        for (int i = 0; i < numberOfValues; i++)
        {
            double value = (random.NextDouble() * 50) - 10;

            writer.WriteLine($"{DateTime.Now},{value.ToString()}");
        }
    }
}
