namespace IDisposableDemo;

/// <summary>
/// Contains logic to read a file with dispose method.
/// </summary>
internal class FileReader : IDisposable
{
    private readonly StreamReader _streamReader;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileReader"/> class.
    /// </summary>
    /// <param name="filePath">The path of the file.</param>
    public FileReader(string filePath)
    {
        this._streamReader = new StreamReader(filePath);
    }

    /// <summary>
    /// Reads the file line by line.
    /// </summary>
    /// <returns>A line from the file that is to be read.</returns>
    public string ReadFile()
    {
        string content = string.Empty;
        string? line;
        while ((line = this._streamReader.ReadLine()) != null)
        {
            content += line;
        }

        return content;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this._streamReader.Dispose();
    }
}
