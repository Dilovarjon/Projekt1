using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface ICredit
    {
        public Credit Create(Guid userId);
        public Credit Repayment(Guid userId);
    }
}
