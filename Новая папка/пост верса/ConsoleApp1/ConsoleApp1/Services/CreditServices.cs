using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Services
{
    public class CreditServices : ICredit
    {
        public Credit Create(Guid userId)
        {
            var credits = new Credit();
            Console.WriteLine("На какую сумму вы хотите взять кредит");
            credits.Amount = decimal.Parse(Console.ReadLine()!);
            Console.WriteLine("На сколько месяцев хотите взять кредит");
            credits.Term = int.Parse(Console.ReadLine()!);
            credits.UserId = userId;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Credits.Add(credits);
                db.SaveChanges();
            }
            return credits;
        }
        public Credit Repayment(Guid userId)
        {
            var credit = new Credit();

            using var db = new ApplicationContext();

            Console.WriteLine("Какой кредит хотите погосить:");
            var credits = db.Credits.Where(x => x.UserId == userId).Include(x => x.User).ToList();
            foreach (var cred in credits)
            {
                Console.WriteLine($"id: {cred.Id} \t Credit: {cred.Amount}");
            }

            Console.Write("Введите id: ");
            var chek = Guid.TryParse(Console.ReadLine(), out Guid id);
            if (!chek)
            {
                throw new Exception("Ошибка конвертации");
            }

            var ReturnCredit = credits.Where(x => x.Id == id).FirstOrDefault();

            Console.Write("На какую сумму хотите погосить кредит: ");
            var repayment = decimal.TryParse(Console.ReadLine(), out decimal result);
            if (!repayment)
            {
                throw new Exception("Ошибка конвертации");
            }

            var chekResult = ReturnCredit?.Amount - result;

            ReturnCredit.Amount = (decimal)chekResult;

            if (chekResult <= 0)
            {
                ReturnCredit.Amount = 0;
                db.Update(ReturnCredit);
            }
            else
            {
                Console.WriteLine($"Осталось {ReturnCredit.Amount} ");
            }
            db.SaveChanges();


            return credit;
        }
    }
}
