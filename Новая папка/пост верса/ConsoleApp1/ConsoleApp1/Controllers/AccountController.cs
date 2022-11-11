using ConsoleApp1.Services;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Controllers
{
    public class AccountController
    {
        private readonly IAccount _account;

        public AccountController()
        {
           _account = new AccountServices();
        }

        public void GetAccountInfo(Guid id)
        {
            // Вывод данных счета
            _account.Account(id);
        }

        public void CreateAccount(Guid id)
        {
            /// Создание счета
            _account.UserAccount(id);
        }

        public void OperationsAccaunt(Guid id)
        {
            /// Операции со счетом
            _account.UserOperationAccount(id);
        }
    }
}