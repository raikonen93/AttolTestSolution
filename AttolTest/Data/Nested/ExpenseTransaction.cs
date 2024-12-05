using AttolTest.Data.Base;

namespace AttolTest.Data.Nested
{
    /// <summary>
    /// Expense transactions representative
    /// </summary>
    public class ExpenseTransaction:Transaction
    {
        public ExpenseTransaction(decimal amount):base(amount)
        {
            
        }
    }
}
