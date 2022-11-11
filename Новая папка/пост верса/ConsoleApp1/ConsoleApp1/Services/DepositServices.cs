using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class DepositServices : IDeposit
    {
        public Deposit Create(Guid userId)
        {
            var deposit = new Deposit();
            Console.WriteLine("На какую сумму вы хотите открыть депозит");
            deposit.Amount = decimal.Parse(Console.ReadLine()!);
            Console.WriteLine("На сколько месяцев хотите оставить депозит");
            deposit.Term = int.Parse(Console.ReadLine()!);
            deposit.UserId = userId;
            using (var db = new ApplicationContext())
            {
                db.Deposits.Add(deposit);
                db.SaveChanges();
            }
            return deposit;
        }
    }
}