using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface IAccount
    {
        void Account(Guid id);
        Account UserAccount(Guid Id);
        Account UserOperationAccount(Guid id);
    }
}
