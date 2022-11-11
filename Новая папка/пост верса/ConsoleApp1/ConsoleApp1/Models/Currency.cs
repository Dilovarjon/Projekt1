namespace ConsoleApp1.Models
{
    public class Currency
    {
        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }
    }
}
