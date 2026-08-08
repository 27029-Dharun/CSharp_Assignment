using Assignment4.Models.Enums;

namespace Assignment4.Models
{
    /// <summary>
    /// Represents a transaction in the system
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="id">Id of the transaction</param>
        /// <param name="title">Description of the transaction</param>
        /// <param name="date">Date of the transaction</param>
        /// <param name="type">Type of the transaction</param>
        /// <param name="category">Category of the transaction</param>
        /// <param name="amount">Amount used in the transaction</param>
        public Transaction(string id, string title, DateTime date, TransactionType type, string category, decimal amount)
        {
            this.Id = id;
            this.Description = title;
            this.Date = date;
            this.Type = type;
            this.Category = category;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets the unique Id assigned to the transaction at creation time.
        /// </summary>
        /// <value>
        /// Unique identifier of the transaction
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Gets or sets the name of the transaction
        /// </summary>
        /// <value>
        /// The name of the transaction
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// gets or sets the Date of the transaction
        /// </summary>
        /// <value>
        /// Date of the transaction
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// gets or sets the type of the transaction
        /// </summary>
        /// <value>
        /// Type of the transaction
        /// </value>
        public TransactionType Type { get; set; }

        /// <summary>
        /// gets or sets the category of the transaction
        /// </summary>
        /// <value>
        /// Category of the transaction
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the Amount used in the transaction
        /// </summary>
        /// <value>
        /// The amount used in the transaction
        /// </value>
        public decimal Amount { get; set; }
    }
}
