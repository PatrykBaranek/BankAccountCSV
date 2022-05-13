using BankAccountCSV;

try
{

    Bank bank = new Bank();
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Choose operation: ");
        Console.WriteLine("1. Show all user accounts");
        Console.WriteLine("2. Make Withdraw or Deposit");
        Console.WriteLine("3. Show all blocked accounts");
        Console.WriteLine("4. Generate raport");
        int userInput = Convert.ToInt32(Console.ReadLine());

        switch (userInput)
        {
            case 1:
                Console.Clear();

                bank.Display(DisplayType.UserAccounts);

                Console.ReadKey();

                break;

            case 2:
                Console.Clear();
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");

                var depositWithdrawChoose = Convert.ToInt32(Console.ReadLine());

                if (depositWithdrawChoose == 1)
                {
                    Console.WriteLine(bank.DepositOrWithdraw(TransactionType.Deposit));
                }
                else if (depositWithdrawChoose == 2)
                {
                    Console.WriteLine(bank.DepositOrWithdraw(TransactionType.Withdraw));
                }
                else
                {
                    throw new Exception("Invalid operation");
                }

                Console.ReadKey();
                break;

            case 3:
                Console.Clear();

                bank.Display(DisplayType.BlockedAccounts);

                Console.ReadKey();
                break;

            case 4:
                Console.Clear();

                bank.Display(DisplayType.Transaction);

                Console.ReadKey();
                break;

            default:
                throw new Exception("Invalid operation");
        }

    }
}
catch (Exception ex)
{
    Console.Clear();

    Console.WriteLine(ex.Message);
}

