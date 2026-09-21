using ExpenseTracker.Models;

namespace ExpenseTracker.Helper;

/// <summary>
/// Generates the unique ID for a transaction.
/// </summary>
public class TransactionIdGenerator
{
    private readonly Dictionary<TransactionType, int> _nextIds = new Dictionary<TransactionType, int>
        {
            { TransactionType.Expense, 100 },
            { TransactionType.Income, 100 },
        };

    /// <summary>
    /// Gets the next id to be used as a identifier.
    /// </summary>
    /// <param name="type">Type of the transaction.</param>
    /// <returns> A unique identifier based on the type of expense. </returns>
    public string GetNextId(TransactionType type)
    {
        string prefix = type == TransactionType.Expense ? "E" : "I";

        int id = this._nextIds[type]++;

        return $"{prefix}{id}";
    }
}
