using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Services
{
    public class AccountServices : IAccount
    {

        /// <summary>
        /// Вывод данных счета 
        /// </summary>
        /// <param name="Id"></param>
        public void Account(Guid Id)
        {
            using var db = new ApplicationContext();
            var user = db.Acconts.Where(x => x.UserId == Id).FirstOrDefault();
            Console.WriteLine($"На вашем счету: {user?.TJK} сомони - {user?.RUB} рублей - {user?.USD} долларов");
        }


        /// <summary>
        /// Создание счета
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Account UserAccount(Guid Id)
        {
            var userBank = new Account();
            using (var db = new ApplicationContext())
            {
                userBank.UserId = Id;
                db.Acconts.Add(userBank);
                db.SaveChanges();
            }
            return userBank;
        }


        /// <summary>
        /// Пополнения счета
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Account UserOperationAccount(Guid id)
        {
            var userBank = new Account();
            using (var db = new ApplicationContext())
            {
                userBank = db.Acconts.Where(x => x.UserId == id).Include(x => x.User).FirstOrDefault()
                    ?? throw new Exception("Ошибка");

                Console.WriteLine("На какую сумму хотите пополнить счет?");
                var chek = decimal.TryParse(Console.ReadLine(), out decimal result);

                if (!chek)
                {
                    throw new Exception("Ошибка конвертации");
                }

                userBank.TJK = userBank.TJK + result;

                db.Acconts.Update(userBank);
                db.SaveChanges();
            }
            return userBank;
        }
    }
}
