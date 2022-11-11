using ConsoleApp1.Controllers;

namespace ConsoleApp1.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public DateTime DatetimeAt { get; set; } = DateTime.Now;

        public Guid BankId { get; set; }
        public Bank? Bank { get; set; }

       
        public Account BankAccount { get; set; }

        public List<Credit> Credits { get; set; } = new();
        public List<Deposit> Deposits { get; set; } = new();

    }
}
