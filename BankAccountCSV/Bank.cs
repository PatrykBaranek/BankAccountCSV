namespace BankAccountCSV
{
    public class Bank
    {
        private readonly List<Account> _accounts = new();
        private readonly List<User> _users = new();
        private List<Transaction> _transactions = new();

        public Bank()
        {
            _accounts = CsvDataLoader<Account>.GetData(@"E:\C#\CsvFiles\konta.csv").OrderBy(a => a.UserId).ToList();
            _users = CsvDataLoader<User>.GetData(@"E:\C#\CsvFiles\osoby.csv");
        }

        public string DepositOrWithdraw(TransactionType transactionType)
        {
            var userId = ChooseUserId();

            var accounts = _accounts.Where(a => a.UserId == userId).ToList();

            if (accounts == null)
            {
                throw new ArgumentNullException("User not found");
            }

            Console.WriteLine("Enter the number of money you want to deposit: ");

            decimal money = Convert.ToDecimal(Console.ReadLine());


            var choosedAccount = ChooseAccount(accounts);

            if (choosedAccount.Balance == 0 && choosedAccount.Balance - money < 0)
            {
                throw new Exception("Cannot make withdrawal with 0 or less than 0 balance");
            }


            if (transactionType == TransactionType.Deposit)
            {

                AddTransaction(choosedAccount, money, TransactionType.Deposit);

                choosedAccount.Balance += money;

                return $"Deposit with {money}, Balance status after transaction: {choosedAccount.Balance}";
            }
            else
            {
                AddTransaction(choosedAccount, money, TransactionType.Withdraw);

                choosedAccount.Balance -= money;

                return $"Withdrawal with {money}, Balance status after transaction: {choosedAccount.Balance}";
            }
        }

        public void Display(DisplayType displayType)
        {

            if (displayType == DisplayType.Transaction)
            {
                if (_transactions.Count == 0)
                {
                    Console.WriteLine("Cannot Generate Report");

                    return;
                }

                Console.WriteLine("\nTransactions:");
                Console.WriteLine("TransactionId | AccountId | Balance | Operation");

                foreach (var transaction in _transactions)
                {
                    bool condition = transaction.TransactionType == TransactionType.Deposit;
                    Console.WriteLine($"{transaction.TransactionId} | {transaction.AccountId} | {transaction.Balance} | {(condition ? string.Join("", '+', transaction.Operation) : string.Join("", '-', transaction.Operation)) }");
                }
            }

            if (displayType == DisplayType.BlockedAccounts)
            {
                Console.WriteLine("\nBlocked accounts:");

                var blockedAccounts = _accounts.Where(a => a.Blockade == "TAK");

                foreach (var account in blockedAccounts)
                {
                    Console.WriteLine($"{account.AccountId}");
                }
            }

            if (displayType == DisplayType.UserAccounts)
            {
                var userId = ChooseUserId();

                var userAccounts = _accounts.Where(a => a.UserId == userId).ToList();

                if (userAccounts.Count == 0)
                {
                    throw new Exception("Cannot find user");
                }

                foreach (var account in userAccounts)
                {
                    Console.WriteLine($"{account.AccountId} {account.UserId} {account.Currency} {account.Balance} {account.Blockade}");
                }
            }
        }

        private Account ChooseAccount(List<Account> accounts)
        {

            if (accounts.Count == 0)
            {
                return null;
            }

            Console.WriteLine("User accounts: ");

            int index = 1;

            foreach (var account in accounts)
            {
                Console.WriteLine($"{index++}. {account.AccountId}");
            }


            Console.WriteLine("Choose One");

            int userChoose = Convert.ToInt32(Console.ReadLine());

            if (userChoose > accounts.Count && userChoose <= 0)
            {
                throw new Exception("Cannot find user account");
            }

            return accounts[userChoose - 1];
        }

        private int ChooseUserId()
        {
            Console.WriteLine("Insert Users ID: ");
            var userId = Convert.ToInt32(Console.ReadLine());

            return userId;
        }

        private void AddTransaction(Account account, decimal money, TransactionType transactionType)
        {
            _transactions.Add(new Transaction()
            {
                TransactionId = _transactions.Count + 1,
                AccountId = account.AccountId,
                Balance = account.Balance,
                Operation = money,
                TransactionType = transactionType
            });
        }

        

    }
}