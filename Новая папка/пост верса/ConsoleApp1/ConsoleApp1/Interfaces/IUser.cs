using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface IUser
    {
        public User SetData();
        public List<User> GetData();
        public void Read(Guid id);
    }
}
