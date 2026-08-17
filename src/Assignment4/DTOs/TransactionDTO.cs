using Assignment4.Models.Enums;

namespace Assignment4.DTOs
{
    /// <summary>
    /// Represents the data required to create/edit a transaction.
    /// </summary>
    public class TransactionDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDTO"/> class.
        /// </summary>
        /// <param name="description">Description of the transaction</param>
        /// <param name="date">Date of the transaction</param>
        /// <param name="type">Type of the transaction</param>
        /// <param name="category">Category of the transaction</param>
        /// <param name="amount">Amount used in the transaction</param>
        public TransactionDTO(string description, DateTime date, TransactionType type, string category, decimal amount)
        {
            this.Description = description;
            this.Date = date;
            this.Type = type;
            this.Category = category;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets or sets the description of the transaction
        /// </summary>
        /// <value>
        /// The description of the transaction
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
