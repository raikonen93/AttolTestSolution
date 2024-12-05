using AttolTest.Data.Base;
using AttolTest.Data.Creator;
using AttolTest.Data.Nested;

string? companyName = string.Empty;
string? command= string.Empty;
//this is not good way to do. In test purposes only
decimal? amountInput = null;

#region initializing account
do
{
    Console.WriteLine("Welcome to the management system!\nTo get started enter your company name and we'll set up an account for you!");
    companyName = Console.ReadLine();
}
while (string.IsNullOrEmpty(companyName));

Account acc=new Account(companyName);
Console.WriteLine("\n\nThank you! Your account has been set up!");
#endregion

#region console input
do
{
    Console.WriteLine("You can use the following commands:\n1 - Check you account balance\n" +
        "2 - Add expense transaction\n" +
        "3 - Add income transaction\n"+
        "4 - Get all expense transactions\n"+
        "5 - Get all income transactions\n"+
        "0 - to exit (but certainly come back friend)\n");
    command = Console.ReadLine();
    if (string.IsNullOrEmpty(command))
        continue;
    
    switch (command)
    {
        case "1":
            Console.WriteLine($"Your balance is {acc.GetBalance()}!\n");
            break;
        case "2":
            if (!EnterAmount())
                continue;
            acc.AddTransaction(TransactionCreator.CreateExpenseTransaction(amountInput.Value));
            break;
        case "3":
            if (!EnterAmount())
                continue;
            acc.AddTransaction(TransactionCreator.CreateIncomeTransaction(amountInput.Value));
            break;
        case "4":
            ShowAllTransations<ExpenseTransaction>();
            break;
        case "5":
            ShowAllTransations<IncomeTransaction>();
            break;
        default:
            Console.WriteLine("Wrong input! Try again! But please don't get angry it's not our fault!\n");
            break;
    }

}
while (command!="0");
#endregion

#region helping methods
bool EnterAmount()
{
    Console.WriteLine("Enter amount:");
    amountInput = ConvertAmountAsDecimal(Console.ReadLine());
    if (!amountInput.HasValue)
    {
        Console.WriteLine("You inputed wrong amount, my friend :(\n");
        return false;
    }
    return true;
}

void ShowAllTransations<T>() where T : Transaction
{
    Console.WriteLine($"All transactions of type {typeof(T).Name} are:");    
    var transactions= acc.GetTransactionByType<T>();
    if(transactions.Count() > 0)
        transactions.ForEach(t => Console.WriteLine(t));
    else
        Console.WriteLine("-------EMPTY----------");
}

decimal? ConvertAmountAsDecimal(string amount) => decimal.TryParse(amount, out decimal decAmount) ? decAmount : null;

#endregion




