using AttolTest.Data.Base;
using AttolTest.Data.Nested;

namespace AttolTest.Data.Creator
{    
    /// <summary>
    /// Transaction factory
    /// </summary>
    public static class TransactionCreator
    {
        public static Transaction CreateExpenseTransaction(decimal amount) => new ExpenseTransaction(amount);
        public static Transaction CreateIncomeTransaction(decimal amount) => new IncomeTransaction(amount);
    }
}
