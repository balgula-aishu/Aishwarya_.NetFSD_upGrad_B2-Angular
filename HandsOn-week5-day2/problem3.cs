using System;


namespace Dotnet_C__Demo.HandsOn_week5_day2
{
    // Custom Exception Class
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // BankAccount Class
    class BankAccount
    {
        private double balance;

        // Constructor
        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        // Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                // Throw custom exception
                throw new InsufficientBalanceException("Error: Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal Successful. Remaining Balance: " + balance);
        }
    }
    internal class problem3
    {
        static void Main()
        {
            Console.Write("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double withdrawAmount = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(balance);

            try
            {
                account.Withdraw(withdrawAmount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction process completed.");
            }

            Console.WriteLine("Program continues running...");
        }
    }
}
