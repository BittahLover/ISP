using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        public interface IAccount
        {
            void Put(decimal sum);
            decimal Withdraw(decimal sum);
        }

        public delegate void AccountStateHandler(object sender, AccountEventArgs e);

        public class AccountEventArgs
        {
           
            public string Message { get; private set; }
        
            public decimal Sum { get; private set; }

            public AccountEventArgs(string _mes, decimal _sum)
            {
                Message = _mes;
                Sum = _sum;
            }
        }

        public abstract class Account : IAccount
        {
           
            protected internal event AccountStateHandler Withdrawed;
            protected internal event AccountStateHandler Added;
            protected internal event AccountStateHandler Opened;
            protected internal event AccountStateHandler Closed;
            protected internal event AccountStateHandler Calculated;

            protected int _id;
            static int counter = 0;

            protected decimal _sum; 
            protected int _percentage; 

            protected int _days = 0; 

            public Account(decimal sum, int percentage)
            {
                _sum = sum;
                _percentage = percentage;
                _id = ++counter;
            }

           
            public decimal CurrentSum
            {
                get { return _sum; }
            }

            public int Percentage
            {
                get { return _percentage; }
            }

            public int Id
            {
                get { return _id; }
            }
            
            private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
            {
                if (handler != null && e != null)
                    handler(this, e);
            }
            
            protected virtual void OnOpened(AccountEventArgs e)
            {
                CallEvent(e, Opened);
            }
            protected virtual void OnWithdrawed(AccountEventArgs e)
            {
                CallEvent(e, Withdrawed);
            }
            protected virtual void OnAdded(AccountEventArgs e)
            {
                CallEvent(e, Added);
            }
            protected virtual void OnClosed(AccountEventArgs e)
            {
                CallEvent(e, Closed);
            }
            protected virtual void OnCalculated(AccountEventArgs e)
            {
                CallEvent(e, Calculated);
            }

            public virtual void Put(decimal sum)
            {
                _sum += sum;
                OnAdded(new AccountEventArgs("На счет поступило " + sum, sum));
            }
            public virtual decimal Withdraw(decimal sum)
            {
                decimal result = 0;
                if (sum <= _sum)
                {
                    _sum -= sum;
                    result = sum;
                    OnWithdrawed(new AccountEventArgs("Сумма " + sum + " снята со счета " + _id, sum));
                }
                else
                {
                    OnWithdrawed(new AccountEventArgs("Недостаточно денег на счете " + _id, 0));
                }
                return result;
            }
            
            protected internal virtual void Open()
            {
                OnOpened(new AccountEventArgs("Открыт новый счет! Id счета: " + this._id, this._sum));
            }
            
            protected internal virtual void Close()
            {
                OnClosed(new AccountEventArgs("Счет " + _id + " закрыт.  Итоговая сумма: " + CurrentSum, CurrentSum));
            }

            protected internal void IncrementDays()
            {
                _days++;
            }
            
            protected internal virtual void Calculate()
            {
                decimal increment = _sum * _percentage / 100;
                _sum = _sum + increment;
                OnCalculated(new AccountEventArgs("Начислены проценты в размере: " + increment, increment));
            }
        }

        public class DemandAccount : Account
        {
            public DemandAccount(decimal sum, int percentage) : base(sum, percentage)
            {
            }

            protected internal override void Open()
            {
                base.OnOpened(new AccountEventArgs("Открыт новый счет до востребования! Id счета: " + this._id, this._sum));
            }
        }

        public class DepositAccount : Account
        {
            public DepositAccount(decimal sum, int percentage) : base(sum, percentage)
            {
            }
            protected internal override void Open()
            {
                base.OnOpened(new AccountEventArgs("Открыт новый депозитный счет!Id счета: " + this._id, this._sum));
            }

            public override void Put(decimal sum)
            {
                if (_days % 30 == 0)
                    base.Put(sum);
                else
                    base.OnAdded(new AccountEventArgs("На счет можно положить только после 30-ти дневного периода", 0));
            }

            public override decimal Withdraw(decimal sum)
            {
                if (_days % 30 == 0)
                    return base.Withdraw(sum);
                else
                    base.OnWithdrawed(new AccountEventArgs("Вывести средства можно только после 30-ти дневного периода", 0));
                return 0;
            }

            protected internal override void Calculate()
            {
                if (_days % 30 == 0)
                    base.Calculate();
            }
        }

        public class Bank<T> where T : Account
        {
            T[] accounts;

            public string Name { get; private set; }

            public Bank(string name)
            {
                this.Name = name;
            }
            
            public void Open(AccountType accountType, decimal sum,
                AccountStateHandler addSumHandler, AccountStateHandler withdrawSumHandler,
                AccountStateHandler calculationHandler, AccountStateHandler closeAccountHandler,
                AccountStateHandler openAccountHandler)
            {
                T newAccount = null;

                switch (accountType)
                {
                    case AccountType.Ordinary:
                        newAccount = new DemandAccount(sum, 1) as T;
                        break;
                    case AccountType.Deposit:
                        newAccount = new DepositAccount(sum, 40) as T;
                        break;
                }

                if (newAccount == null)
                    throw new Exception("Ошибка создания счета");
                if (accounts == null)
                    accounts = new T[] { newAccount };
                else
                {
                    T[] tempAccounts = new T[accounts.Length + 1];
                    for (int i = 0; i < accounts.Length; i++)
                        tempAccounts[i] = accounts[i];
                    tempAccounts[tempAccounts.Length - 1] = newAccount;
                    accounts = tempAccounts;
                }
                
                newAccount.Added += addSumHandler;
                newAccount.Withdrawed += withdrawSumHandler;
                newAccount.Closed += closeAccountHandler;
                newAccount.Opened += openAccountHandler;
                newAccount.Calculated += calculationHandler;

                newAccount.Open();
            }
           
            public void Put(decimal sum, int id)
            {
                T account = FindAccount(id);
                if (account == null)
                    throw new Exception("Счет не найден");
                account.Put(sum);
            }
           
            public void Withdraw(decimal sum, int id)
            {
                T account = FindAccount(id);
                if (account == null)
                    throw new Exception("Счет не найден");
                account.Withdraw(sum);
            }
            
            public void Close(int id)
            {
                int index;
                T account = FindAccount(id, out index);
                if (account == null)
                    throw new Exception("Счет не найден");

                account.Close();

                if (accounts.Length <= 1)
                    accounts = null;
                else
                {
                    T[] tempAccounts = new T[accounts.Length - 1];
                    for (int i = 0, j = 0; i < accounts.Length; i++)
                    {
                        if (i != index)
                            tempAccounts[j++] = accounts[i];
                    }
                    accounts = tempAccounts;
                }
            }
            
            public void CalculatePercentage()
            {
                if (accounts == null) 
                    return;
                for (int i = 0; i < accounts.Length; i++)
                {
                    T account = accounts[i];
                    account.IncrementDays();
                    account.Calculate();
                }
            }
            
            public T FindAccount(int id)
            {
                for (int i = 0; i < accounts.Length; i++)
                {
                    if (accounts[i].Id == id)
                        return accounts[i];
                }
                return null;
            }

            public T FindAccount(int id, out int index)
            {
                for (int i = 0; i < accounts.Length; i++)
                {
                    if (accounts[i].Id == id)
                    {
                        index = i;
                        return accounts[i];
                    }
                }
                index = -1;
                return null;
            }
        }
        
        public enum AccountType
        {
            Ordinary,
            Deposit
        }



        static void Main(string[] args)
        {
            Bank<Account> bank = new Bank<Account>("MemDepositBank");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue; 
                Console.WriteLine("1. Открыть счет \t 2. Вывести средства  \t 3. Добавить на счет");
                Console.WriteLine("4. Закрыть счет \t 5. Пропустить день \t 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            OpenAccount(bank);
                            break;
                        case 2:
                            Withdraw(bank);
                            break;
                        case 3:
                            Put(bank);
                            break;
                        case 4:
                            CloseAccount(bank);
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    bank.CalculatePercentage();
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }


        private static void OpenAccount(Bank<Account> bank)
        {
            Console.WriteLine("Укажите сумму для создания счета:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Выберите тип счета: 1. До востребования 2. Депозит");
            AccountType accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 2)
                accountType = AccountType.Deposit;
            else
                accountType = AccountType.Ordinary;

            bank.Open(accountType, sum, AddSumHandler, WithdrawSumHandler, (o, e) => Console.WriteLine(e.Message), CloseAccountHandler, OpenAccountHandler); 
        }

        private static void Withdraw(Bank<Account> bank)
        {
            Console.WriteLine("Укажите сумму для вывода со счета:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите id счета:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Withdraw(sum, id);
        }

        private static void Put(Bank<Account> bank)
        {
            Console.WriteLine("Укажите сумму, чтобы положить на счет:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите Id счета:");
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Put(sum, id);
        }

        private static void CloseAccount(Bank<Account> bank)
        {
            Console.WriteLine("Введите id счета, который надо закрыть:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Close(id);
        }
       
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
                Console.WriteLine("Идем тратить деньги");
        }
        
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
