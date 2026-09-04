namespace IDisposableDemo;

/// <summary>
/// Contains logic to write a file with disposable methods.
/// </summary>
public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileWriter"/> class.
    /// </summary>
    /// <param name="path">The path of the file to be written</param>
    public FileWriter(string path)
    {
        if (!File.Exists(path))
        {
            using (File.Create(path))
            {
            }
        }

        this._streamWriter = new StreamWriter(path);
    }

    /// <summary>
    /// Writes string in the file.
    /// </summary>
    /// <param name="text">Text to be written in the file.</param>
    public void Write(string text)
    {
        this._streamWriter.Write(text);
    }

    /// <summary>
    /// Disposes the stream writer.
    /// </summary>
    public void Dispose()
    {
        this._streamWriter.Dispose();
    }
}
