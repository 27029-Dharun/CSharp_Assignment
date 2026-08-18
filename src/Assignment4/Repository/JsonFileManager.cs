using System.Text.Json;
using System.Text.Json.Serialization;
using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Contains the Write and load logics that writes and loads the file in json format.
    /// </summary>
    public class JsonFileManager
    {
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonFileManager"/> class.
        /// </summary>
        public JsonFileManager()
        {
            this._options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() },
            };
        }

        /// <summary>
        /// Writes all the transaction to the file
        /// </summary>
        /// <param name="filePath">The path of the file where the transaction are stored</param>
        /// <param name="list">List of the transaction that are to be added</param>
        public void WriteAll(string filePath, List<Transaction> list)
        {
            string json = JsonSerializer.Serialize(list, this._options);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Loads all the content and loads into the file
        /// </summary>
        /// <param name="filePath">Path of the file from which the contents are loaded </param>
        /// <returns>A list of transactions that are stored in the file</returns>
        public List<Transaction> LoadAll(string filePath)
        {
            string text = File.ReadAllText(filePath);
            List<Transaction>? transactions = JsonSerializer.Deserialize<List<Transaction>>(text, this._options);
            if (transactions is null)
            {
                return new List<Transaction>();
            }

            return transactions;
        }
    }
}
