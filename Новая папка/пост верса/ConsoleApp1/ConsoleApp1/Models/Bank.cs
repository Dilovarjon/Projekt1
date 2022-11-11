namespace ConsoleApp1.Models
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public List<User> Users { get; set; } = new();
    }
}
