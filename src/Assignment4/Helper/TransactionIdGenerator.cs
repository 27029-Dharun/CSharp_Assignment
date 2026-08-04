using Assignment4.Models.Enums;

namespace Assignment4.Helper
{
    /// <summary>
    /// generates the id for transactions
    /// </summary>
    public class TransactionIdGenerator
    {
        private readonly Dictionary<TransactionType, int> _transactionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIdGenerator"/> class.
        /// </summary>
        public TransactionIdGenerator()
        {
            this._transactionId = new Dictionary<TransactionType, int>
            {
                { TransactionType.Expense, 100 },
                { TransactionType.Income, 100 },
            };
        }

        /// <summary>
        /// returns the next id to be used as a identifier
        /// </summary>
        /// <param name="type">Type of the transaction</param>
        /// <returns>unique indentifier based on the type of expense</returns>
        public string GetNextId(TransactionType type)
        {
            string prefix = type == TransactionType.Expense ? "E" : "I";

            int id = this._transactionId[type]++;
            return prefix + id;
        }
    }
}
