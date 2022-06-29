using System;
using System.Globalization;
using TratamentoErros.Entities;
using TratamentoErros.Entities.Exceptions;

namespace TratamentoErros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data:");

                Console.Write("Number: ");
                int accNumber = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string acctHolder = Console.ReadLine();
                Console.Write("Iinitial balance: ");
                double accInitialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double accWithdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(accNumber, acctHolder, accInitialBalance, accWithdrawLimit);
                Console.WriteLine();

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                acc.Withdraw(amount);

                Console.Write("New balance: " + acc.Balance);
                Console.WriteLine();
            }
            catch (DomainException err)
            {
                Console.WriteLine("Withdraw error: " + err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine("Unexpected error: " + err.Message);
            }
        }
    }
}
