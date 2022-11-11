namespace ConsoleApp1.Models
{
    public class Credit
    {
        public Guid Id { get; set; }
        
        public decimal Amount { get; set; }

        public decimal Percentage = 0.03M;

        public int Term { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
