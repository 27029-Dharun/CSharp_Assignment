namespace Assignment4.Validation
{
    /// <summary>
    /// 
    /// </summary>
    internal class TransactionValidator
    {
        internal string ValidateAmount(decimal amount)
        {
            if (amount < 0)
            {
                return "Amount should be positive";
            }
        }

        internal string ValidateDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                return "Date should not be ";
            }

            return string.Empty;
        }

        internal string ValidateName(string name)
        {
            if (name == null || name.Length < 3)
            {
                return "Name should have at least 3 Characters";
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return "Name should only contain Alphabets";
                }
            }

            return string.Empty;
        }
    }
}
