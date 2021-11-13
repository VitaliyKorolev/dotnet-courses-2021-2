using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace BLL
{
    public class UserManager:IUserBL
    {
        private readonly IUserDAO _userDAO;

        public UserManager(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public void DeleteUser(User user)
        {
            _userDAO.DeleteUser(user);
        }
        public void AddUser(User user)
        {
           _userDAO.AddUser(user);
        }
       
        public IList<User> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public void AddRevardToUser(User user, Reward reward)
        {
            if (!user.Rewards.Contains(reward))
            {
                user.Rewards.Add(reward);
            }
        }
        
        public void DeleteRevardFromUser(User user, Reward reward)
        {
            if (user.Rewards.Contains(reward))
            {
                user.Rewards.Remove(reward);
            }
        }
      

    }
}
