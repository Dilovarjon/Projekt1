using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;

namespace ConsoleApp1.Controllers
{
    public class DepositController
    {
        private readonly IDeposit _deposit;
        public DepositController()
        {
            _deposit = new DepositServices();
        }

        public void Create(Guid Id)
        {
            _deposit.Create(Id);
        }
    }
}
