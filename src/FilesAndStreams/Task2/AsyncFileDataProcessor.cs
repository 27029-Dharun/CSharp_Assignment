using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Task2;

/// <summary>
/// Read and write asynchronously.
/// </summary>
internal class AsyncFileDataProcessor
{
    private const string _firstPath = "file1.txt";
    private const string _secondPath = "file2.txt";
    private const string _thirdPath = "file3.txt";

    /// <summary>
    /// Reads the file
    /// </summary>
    /// <returns>A task is returned</returns>
    internal async Task Run()
    {
        string menuOptions = "1. Create 3 large file with 1 GB\n" +
            "2. Read the file\n" +
            "3. Process file and write\n" +
            "4. Exit\n" +
            "Enter an option to proceed: ";

        while (true)
        {
            int option = ConsoleIO.GetInteger(menuOptions);

            switch (option)
            {
                case 1:
                    await this.GenerateAll();
                    break;

                case 2:
                    await this.ReadAll();
                    break;

                case 3:
                    string data = this.ProcessData(_firstPath);
                    this.WriteProcessedString("data.txt", data);
                    break;

                case 4:
                    return;

                case 5:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }

    private async Task ReadAll()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Task firstFileRead = this.ReadWithFileStream(_firstPath);
        Task secondFileRead = this.ReadWithFileStream(_secondPath);
        Task thirdFileRead = this.ReadWithFileStream(_thirdPath);

        await Task.WhenAll(firstFileRead, secondFileRead, thirdFileRead);
        stopwatch.Stop();

        Console.WriteLine("Time taken to read with file stream: " + stopwatch.ElapsedMilliseconds);

        stopwatch.Restart();

        Task firstFileReadBuffer = this.ReadWithBufferedStream(_firstPath);
        Task secondFileReadBuffer = this.ReadWithBufferedStream(_secondPath);
        Task thirdFileReadBuffer = this.ReadWithBufferedStream(_thirdPath);

        await Task.WhenAll(firstFileReadBuffer, secondFileReadBuffer, thirdFileReadBuffer);
        stopwatch.Stop();
        Console.WriteLine("Time taken to read with buffered stream: " + stopwatch.ElapsedMilliseconds);
    }

    private async Task GenerateAll()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Task firstFile = this.GenerateFileAsync(_firstPath, 100_00_000);
        Task secondFile = this.GenerateFileAsync(_secondPath, 100_00_000);
        Task thirdFile = this.GenerateFileAsync(_thirdPath, 100_00_000);

        await Task.WhenAll(firstFile, secondFile, thirdFile);
        stopwatch.Stop();

        Console.WriteLine("Time taken to create 3 file " + stopwatch.ElapsedMilliseconds);
    }

    private void WriteProcessedString(string path, string data)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            byte[] array = Encoding.UTF8.GetBytes(data);
            stream.Write(array, 0, array.Length);

            // Reset the position after writing to read from beginning.
            stream.Position = 0;

            using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
        }
    }

    private async Task ReadWithFileStream(string path)
    {
        Console.WriteLine($"Reading {path} with FileStream {DateTime.Now}");
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            byte[] buffer = new byte[4 * 1024];
            int bytesRead;
            long totalBytesRead = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            stopwatch.Stop();

            Console.WriteLine($"Reading {path} with FileStream {DateTime.Now} in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    private async Task ReadWithBufferedStream(string path)
    {
        Console.WriteLine($"Reading {path} with buffered stream {DateTime.Now}");
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new BufferedStream(stream, 32 * 1024))
            {
                byte[] buffer = new byte[4 * 1024];
                int bytesRead;
                long totalBytesRead = 0;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while ((bytesRead = await bufferedStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                stopwatch.Stop();

                Console.WriteLine($"Reading {path} with buffered stream {DateTime.Now} in {stopwatch.ElapsedMilliseconds} ms");
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

                Console.WriteLine("Time taken to process : " + stopwatch.ElapsedMilliseconds);
                return $"Minimum Temperature: {minTemperature}\nMaximum Temperature: {maxTemperature}\nAverage Temperature: {sum / count}\n";
            }
        }
    }

    private async Task GenerateFileAsync(string path, int numberOfValues)
    {
        //if (File.Exists(path))
        //{
        //    Console.WriteLine($"File {path} already exists");
        //    return;
        //}

        Console.WriteLine($"Started creating {path}");
        using (StreamWriter writer = new StreamWriter(path))
        {
            Random random = new Random();

            for (int i = 0; i < numberOfValues; i++)
            {
                double value = random.NextDouble() * 50 - 10;

                await writer.WriteLineAsync(value.ToString());
            }
        }

        Console.WriteLine($"{path} file created.");
    }
}