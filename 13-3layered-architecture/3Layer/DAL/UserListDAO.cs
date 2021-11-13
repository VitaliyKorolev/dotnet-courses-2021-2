using Entities;
using System;
using System.Collections.Generic;
using Interfaces;

namespace DAL
{
    public class UserListDAO:IUserDAO
    {
        private readonly List<User> _users = new List<User>()
        {
            new User(DateTime.Today.AddYears(-20), "Valeriy", "Andreev")

        };

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }
        public void AddUser(User user)
        {
            _users.Add(user);
        } 
        public IList<User> GetAllUsers()
        {
            return _users.ToArray();
        }
       
    }
}
