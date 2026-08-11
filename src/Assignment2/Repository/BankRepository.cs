using Assignment2.Models.BankingSystem;

namespace Assignment2.Repository;

/// <summary>
/// Provides a centralized data repository for storing, retrieving active bank account entities.
/// </summary>
internal class BankRepository
{
    private readonly List<BankAccount> _accounts = new List<BankAccount>();

    /// <summary>
    /// Adds a bank account of a new customer into the repository.
    /// </summary>
    /// <param name="bankAccount"> A bank account instance that is need to be added. </param>
    internal void Add(BankAccount bankAccount)
    {
        this._accounts.Add(bankAccount);
    }

    /// <summary>
    /// Finds the account with matching account number.
    /// </summary>
    /// <param name="accountNumber">Account number.</param>
    /// <returns>The bank account instance</returns>
    internal BankAccount? GetByAccountNumber(string accountNumber)
    {
        return this._accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
    }

    /// <summary>
    /// Deducts a sum of amount from an account.
    /// </summary>
    /// <param name="accountNumber"> Account number of the account where amount is to be withdrawn. </param>
    /// <param name="amount"> A sum of amount that is to be withdrawn. </param>
    /// <returns> A string containing the status of the withdrawal operation. </returns>
    internal bool WithdrawAmount(string accountNumber, decimal amount)
    {
        BankAccount? account = this.GetByAccountNumber(accountNumber);
        if (account is null)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Deposits a sum of amount into an account.
    /// </summary>
    /// <param name="accountNumber"> Account number where amount is to be deposited. </param>
    /// <param name="amount"> A sum of amount to be deposited. </param>
    /// <returns>A string containing the status of the deposit operation</returns>
    internal bool DepositAmount(string accountNumber, decimal amount)
    {
        BankAccount? account = this.GetByAccountNumber(accountNumber);
        if (account is null)
        {
            return false;
        }

        return true;
    }
}
