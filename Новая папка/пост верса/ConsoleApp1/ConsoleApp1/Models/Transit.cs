namespace ConsoleApp1.Models
{
    public class Transit
    {
        public Guid Id { get; set; }

        public decimal Amout { get; set; }
        
        public decimal converted_amount { get; set; }
        
        public string from_currency { get; set; }
        
        public string to_currency { get; set; }
        
        public decimal cur_rate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
