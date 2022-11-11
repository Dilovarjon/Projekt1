namespace ConsoleApp1.Models
{
    public class Deposit
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public int Term { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
