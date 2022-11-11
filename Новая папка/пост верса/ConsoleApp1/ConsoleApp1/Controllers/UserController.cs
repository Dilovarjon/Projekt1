using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Controllers
{
    public class UserController
    {
        private readonly IUser _user;
        /*public UserController(out List<User> user)
        {
            var userService = new UserServices();
            userService.SetData();
            user = userService.GetData();
        }*/
        public UserController()
        {
            _user = new UserServices();
        }


        public void SetData(out List<User> user)
        {
            _user.SetData();
            user = _user.GetData();
        }
        public void Read(Guid id)
        {
            _user.Read(id);
        }/*
        public UserController(Guid Id)
        {
            var userService = new UserServices();
            userService.Read(Id);
        }*/
    }
}
