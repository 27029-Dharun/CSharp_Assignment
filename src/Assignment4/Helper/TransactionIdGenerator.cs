using System.Text.Json;
using Assignment4.Models.Enums;

namespace Assignment4.Helper
{
    /// <summary>
    /// Generates the id for each transactions.
    /// </summary>
    public class TransactionIdGenerator
    {
        private readonly Dictionary<TransactionType, int> _transactionId;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIdGenerator"/> class.
        /// </summary>
        /// <param name="path">Path of the file to  store the id</param>
        public TransactionIdGenerator(string path)
        {
            this._filePath = path;
            if (!File.Exists(this._filePath))
            {
                File.WriteAllText(this._filePath, string.Empty);
                this._transactionId = new Dictionary<TransactionType, int>
                {
                    { TransactionType.Expense, 100 },
                    { TransactionType.Income, 100 },
                };
                return;
            }

            this._transactionId = this.GetLastIdFromFile();
        }

        /// <summary>
        /// Gets the next id to be used as a identifier.
        /// </summary>
        /// <param name="type">Type of the transaction</param>
        /// <returns> A unique identifier based on the type of expense. </returns>
        public string GetNextId(TransactionType type)
        {
            string prefix = type == TransactionType.Expense ? "E" : "I";

            int id = this._transactionId[type]++;
            this.WriteFile();
            return prefix + id;
        }

        private void WriteFile()
        {
            string json = JsonSerializer.Serialize(this._transactionId);
            File.WriteAllText(this._filePath, json);
        }

        private Dictionary<TransactionType, int> GetLastIdFromFile()
        {
            Dictionary<TransactionType, int>? dictionary = JsonSerializer.Deserialize<Dictionary<TransactionType, int>>(File.ReadAllText(this._filePath));
            if (dictionary is null)
            {
                return new Dictionary<TransactionType, int>();
            }

            return dictionary;
        }
    }
}