using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Services
{
    public class UserServices : IUser
    {

        public User SetData()
        {
            var user = new User();
            var userbank = new AccountServices();

            Console.WriteLine("Как зовут клиента? ");
            user.Name = Console.ReadLine()!;
            Console.WriteLine("Какая у вас фамилия? ");
            user.Surname = Console.ReadLine()!;
            Console.WriteLine("Сколько вам лет?");
            bool b = int.TryParse(Console.ReadLine(), out int result);
            user.Age = result;
            using (var db = new ApplicationContext())
            {
                user.BankId = db.Banks.Where(x => x.Name == "Эсхата").Select(c => c.Id).FirstOrDefault();
                user.BankAccount = db.Acconts.Where(x => x.UserId == user.Id).FirstOrDefault();
                db.Users.Add(user);
                db.SaveChanges();
            }
                userbank.UserAccount(user.Id);
            return user;
        }

        public List<User> GetData()
        {
            using var db = new ApplicationContext();
            return db.Users.ToList();
        }


        public void Read(Guid id)
        {
            using var db = new ApplicationContext();
            var user = db.Users
                .Where(x => x.Id == id)
                .Include(x => x.Credits)
                .FirstOrDefault();

            var credit = db.Credits.Where(x => x.UserId == id).Include(x => x.User).ToList().Select(x => x.Amount);
            var deposit = db.Deposits.Where(x => x.UserId == id).Include(x => x.User).ToList().Select(x => x.Amount);

            Console.WriteLine("Сведения о Клиенте:");
            Console.WriteLine($"Имя: {user!.Name}");
            Console.WriteLine($"Фамилия: {user.Surname}");
            Console.WriteLine($"Возраст: {user.Age}");

            foreach (var c in credit)
            {
                Console.WriteLine($"Кредит:  {c}");
            }
            foreach (var d in deposit)
            {
                Console.WriteLine($"Депозит:  {d}");
            }
        }
    }
}
