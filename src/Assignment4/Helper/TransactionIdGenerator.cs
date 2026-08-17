using Assignment4.Models.Enums;

namespace Assignment4.Helper
{
    /// <summary>
    /// Generates the id for each transactions.
    /// </summary>
    public class TransactionIdGenerator
    {
        private readonly Dictionary<TransactionType, int> _transactionId;
        private string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIdGenerator"/> class.
        /// </summary>
        /// <param name="path">Path of the file</param>
        public TransactionIdGenerator(string path)
        {
            this._path = path;
            if (!File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
                this._transactionId = new Dictionary<TransactionType, int>
                {
                    { TransactionType.Expense, 100 },
                    { TransactionType.Income, 100 },
                };
            }

            this._transactionId = new Dictionary<TransactionType, int>
                {
                    { TransactionType.Expense, 100 },
                    { TransactionType.Income, 100 },
                };
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
            WriteAll();
            return prefix + id;
        }

        private void WriteAll()
        {
            throw new NotImplementedException();
        }
    }
}
