using System.Text;

namespace FilesAndStreams.Task3;

/// <summary>
/// Contains the memory optimization.
/// </summary>
internal class MemoryStreamWriter
{
    /// <summary>
    /// Writes in the file.
    /// </summary>
    internal void WriteAndReadFile()
    {
        string path = "fileWriter.txt";
        string data = "This is some test data";

        // Writing to file using MemoryStream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            memoryStream.Write(buffer, 0, buffer.Length);

            // Write from MemoryStream to file
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }

        // Reading from file using FileStream
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string text = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(text);
            }
        }
    }
}
