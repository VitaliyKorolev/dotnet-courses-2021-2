using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserBL
    {
        public void DeleteUser(User user);
        public void AddUser(User user);
        public IList<User> GetAllUsers();
        public void AddRevardToUser(User user, Reward reward);
        public void DeleteRevardFromUser(User user, Reward reward);
        
    }
}
