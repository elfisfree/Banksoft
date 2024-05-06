class Program
{
    static void Main(string[] args)
    {
        List<BankAccount> bankAccounts = new List<BankAccount>()
        {
            new BankAccount("Ivanov", 156000, new DateTime(2001,12,12), false),
            new BankAccount("Petrov", 1506700, new DateTime(1997,06,11), false),
            new BankAccount("P0pov", 5100, new DateTime(1999,12,04), true),
            new BankAccount("Ivanova", 1123012, new DateTime(2000,06,02), false),
            new BankAccount("Garkun", 29006, new DateTime(2003,02,03), false),
            new BankAccount("Yarullin", 310, new DateTime(2003,03,03), true),
            new BankAccount("Gigihadidov", 33000, new DateTime(2000,05,10), false),
            new BankAccount("Pepperoni", 33000, new DateTime(2000,05,10), true)
        };
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Введите:");
            Console.WriteLine("1 - для вывода списка всех банковских аккаунтов");
            Console.WriteLine("2 - для вывода списка аккаунтов с балансом больше 11000");
            Console.WriteLine("3 - для сортировки аккаунтов (по алфавиту, по балансу от большего к меньшему и от меньшего к большему)");
            Console.WriteLine("4 - для вывода списка забаненных аккаунтов с балансом меньше 10к");
            Console.WriteLine("5 - для вывода списка аккаунтов пользователи которые родились до 2000 года");
            Console.WriteLine("6 - КОММУНИЗМ!!!!");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Все аккаунты:");
                    PrintBankAccounts(bankAccounts);
                    break;
                case "2":
                    List<BankAccount> accountsWithHighBalance = bankAccounts.Where(account => account.Balance > 11000).ToList();
                    Console.WriteLine("Аккаунты на счетах которых больше 11000:");
                    PrintBankAccounts(accountsWithHighBalance);
                    break;
                case "3":
                    SortBankAccounts(bankAccounts);
                    Console.WriteLine("Отсортированные аккаунты:");
                    
                    break;
                case "4":
                    List<BankAccount> bannedAccountsLowBalance = bankAccounts.Where(account => account.IsBan && account.Balance < 10000).ToList();
                    Console.WriteLine("Забаненные аккаунты с балансом меньше 10к:");
                    PrintBankAccounts(bannedAccountsLowBalance);
                    break;
                case "5":
                    List<BankAccount> accountsBornBefore2000 = bankAccounts.Where(account => account.Birthday.Year < 2000).ToList();
                    Console.WriteLine("Аккаунты пользователей, родившихся до 2000 года:");
                    PrintBankAccounts(accountsBornBefore2000);
                    break;
                case "6":
                    ToCommunism(bankAccounts);
                    Console.WriteLine("ПАРТИЯ РАДА, БАЛАНСЫ БЫЛИ РАЗДЕЛЕНЫ +1000 ХРУЩЕВКА.");
                    PrintBankAccounts(bankAccounts);
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите 1, 2, 3, 4 или 5");
                    break;
            }
        }
    }
    static void PrintBankAccounts(List<BankAccount> accounts)
    {
        foreach (BankAccount bankAccount in accounts)
        {
            Console.WriteLine($"Имя: {bankAccount.Name}, Баланс счета: {bankAccount.Balance} руб., дата рожд. {bankAccount.Birthday} , Бан: {bankAccount.IsBan}");
        }
    }
    static void ToCommunism(List<BankAccount> accounts)
    {
        decimal totalBalance = accounts.Sum(account => account.Balance);
        decimal newBalance = totalBalance / accounts.Count;
        foreach (var account in accounts)
        {
            account.Balance = newBalance;
        }
    }
    static void SortBankAccounts(List<BankAccount> accounts)
    {
        Console.WriteLine("Выберите тип сортировки:");
        Console.WriteLine("1 - По алфавиту (по имени)");
        Console.WriteLine("2 - По балансу (от большего к меньшему)");
        Console.WriteLine("3 - По балансу (от меньшего к большему)");

        string sortTypeInput = Console.ReadLine();
        switch (sortTypeInput)
        {
            case "1":
                accounts.Sort((a, b) => string.Compare(a.Name, b.Name));
                break;
            case "2":
                accounts.Sort((a, b) => b.Balance.CompareTo(a.Balance));
                break;
            case "3":
                accounts.Sort((a, b) => a.Balance.CompareTo(b.Balance));
                break;
            default:
                Console.WriteLine("Неверный ввод. Сортировка не выполнена.");
                break;
        }
    }
}
class BankAccount
{
    public BankAccount(string name, decimal balance, DateTime birthday, bool isBan)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Balance = balance;
        Birthday = birthday;
        IsBan = isBan;
    }

    public string Id { get; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public DateTime Birthday { get; set; }
    public bool IsBan { get; set; }
}