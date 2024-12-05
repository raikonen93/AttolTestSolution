using AttolTest.Data.Nested;


namespace AttolTest.Data.Base
{
    /// <summary>
    /// Account representative class
    /// </summary>
    public class Account
    {
        public string AccountName { get; set; }= "Default";
        public List<Transaction> ListOfTransactions { get; set; } = new();

        #region public methods
        public void AddTransaction(Transaction transactionToAdd)
        {
            ListOfTransactions.Add(transactionToAdd);
        }       

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (Transaction transaction in ListOfTransactions)
            {
                if(transaction is IncomeTransaction)
                {
                    balance += transaction.OperationAmount;
                }
                else if(transaction is ExpenseTransaction)
                {
                    balance -= transaction.OperationAmount;
                }
            }
            return balance;
        }

        public List<T> GetTransactionByType<T>() where T : Transaction 
        {
            return ListOfTransactions.OfType<T>().ToList();
        }
        #endregion

        #region ctor   
        public Account(string accountName)
        {
            AccountName = accountName; 
        }
        #endregion
    }
}
