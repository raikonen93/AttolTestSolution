namespace AttolTest.Data.Base
{
    /// <summary>
    /// Base class for all transactions
    /// </summary>
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public DateOnly OperationDate { get; set; }
        public decimal OperationAmount { get; set; }
        public string GetDetails()=>$"Operation date is {OperationDate}. Operations Amount is {OperationAmount}."; 
        public override string ToString()
        {
            return GetDetails();
        }
        public Transaction(decimal amount)
        {
            TransactionId = Guid.NewGuid();
            OperationAmount = amount;
            OperationDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
