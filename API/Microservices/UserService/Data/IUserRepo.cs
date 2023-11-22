using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetUserByUsername(string name);
        User GetUserById(int id);
        void CreateUser(User user);
         
    }
}