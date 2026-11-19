using System.Text;

namespace FilesAndStreams.Task3;

/// <summary>
/// Contains the memory optimization.
/// </summary>
internal class MemoryStreamWriter
{
    private const string FilePath = "fileWriter.txt";
    private const string TextData = "This is some test data";

    /// <summary>
    /// Writes in the data in the file through MemoryStream and reads it back.
    /// </summary>
    internal void WriteAndReadFile()
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            byte[] buffer = Encoding.ASCII.GetBytes(TextData);
            memoryStream.Write(buffer, 0, buffer.Length);

            using (FileStream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }

        using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string text = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(text);
            }
        }
    }
}
