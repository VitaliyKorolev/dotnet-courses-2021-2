using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IUserDAO
    {
        public void DeleteUser(User user);
        public void AddUser(User user);
        public IList<User> GetAllUsers();
        
    }
}
