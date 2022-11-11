using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public decimal TJK { get; set; } = 0;

        public decimal RUB { get; set; } = 0;

        public decimal USD { get; set; } = 0;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}