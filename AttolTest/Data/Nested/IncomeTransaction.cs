using AttolTest.Data.Base;

namespace AttolTest.Data.Nested
{
    /// <summary>
    /// Income transactions representative
    /// </summary>
    public class IncomeTransaction:Transaction
    {
        public IncomeTransaction(decimal amount):base(amount)
        {
            
        }
    }
}
