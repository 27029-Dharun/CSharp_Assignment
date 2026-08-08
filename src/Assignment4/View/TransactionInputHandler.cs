using Assignment4.DTOs;
using Assignment4.Models.Enums;

namespace Assignment4.View
{
    /// <summary>
    /// Get the transaction.
    /// </summary>
    internal class TransactionInputHandler
    {
        private ConsoleView _view = new ConsoleView();

        /// <summary>
        /// Gets the data for editing a transaction
        /// </summary>
        /// <param name="transaction">A transaction instance</param>
        /// <returns>True if</returns>
        public bool EditTransactionInputHandler(TransactionDTO transaction)
        {
            int option = this._view.GetOptionalInteger("Enter the field to edit.\n1. Category\n2. Amount\n3. Date\n4. Description\n");

            switch (option)
            {
                case 1:

                    transaction.Category = this.GetCategory(transaction.Type);
                    break;

                case 2:

                    if (!this._view.GetDecimal($"Enter the {transaction.Type} amount: ", out decimal amount))
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return false;
                    }

                    transaction.Amount = amount;
                    break;

                case 3:

                    if (!this._view.GetDate(out DateTime date))
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return false;
                    }

                    transaction.Date = date;
                    break;

                case 4:

                    if (!this._view.GetString($"Enter the {transaction.Type} title: ", out string description))
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return false;
                    }

                    transaction.Description = description;
                    break;

                default:
                    this._view.PrintInfo("Enter a valid transaction.");
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the input from the user for creating a transaction.
        /// </summary>
        /// <returns>Transaction data instance</returns>
        public TransactionDTO? CreateTransactionInputHandler()
        {
            TransactionType type = this._view.GetEnumValue<TransactionType>("Select the type of the transaction: ");

            // Gets the category of the transaction
            string category = this.GetCategory(type);

            // Gets the amount involved in the transaction
            if (!this._view.GetDecimal($"Enter the {type} amount: ", out decimal amount))
            {
                return null;
            }

            // Gets the date of the transaction
            if (!this._view.GetDate(out DateTime date))
            {
                return null;
            }

            // Gets the description
            if (!this._view.GetString($"Enter the {type} description: ", out string description))
            {
                return null;
            }

            // Creates the transaction DTO
            return new TransactionDTO(description, date, type, category, amount);
        }

        private string GetCategory(TransactionType? type)
        {
            if (type is TransactionType.Expense)
            {
                return this._view.GetEnumValue<ExpenseCategory>($"Select the category of the {type}: ").ToString();
            }
            else
            {
                return this._view.GetEnumValue<IncomeCategory>($"Select the category of the {type}: ").ToString();
            }
        }
    }
}
