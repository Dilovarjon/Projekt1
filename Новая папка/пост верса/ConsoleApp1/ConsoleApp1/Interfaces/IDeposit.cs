using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface IDeposit
    {
        public Deposit Create(Guid userId);
    }
}
