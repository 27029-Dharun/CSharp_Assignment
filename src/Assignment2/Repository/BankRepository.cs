using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.BankingSystem;

namespace Assignment2.Repository
{
    internal class BankRepository
    {
        private List<BankAccount> _accounts = new List<BankAccount>();

        internal string CreateAccount(BankAccount bankAccount)
        {
            _accounts.Add(bankAccount);
        }

        internal BankAccount GetAllAccounts()
        {
            List<BankAccount> copy = new List<BankAccount>();
            foreach (BankAccount a in this._accounts)
            {
                copy.Add(new Contact { Id = a.Id, Name = a.Name, Phone = a.Phone, Email = a.Email, Notes = a.Notes });
            }

            return copy;
        }
    }
}
