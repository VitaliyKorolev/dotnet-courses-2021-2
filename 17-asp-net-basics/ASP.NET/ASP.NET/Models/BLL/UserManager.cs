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


        public void AddUser(User user)
        {
            _userDAO.AddUser(user);
        }

        public void DeleteUser(User user)
        {
            _userDAO.DeleteUser(user);
        }

        public void EditUser(User user, string newName, string newLastName, DateTime newBirthDay, List<Reward> newRewards)
        {
            _userDAO.EditUser(user, newName, newLastName, newBirthDay);
            _userDAO.DeleteRewardsOfUser(user);
            foreach (Reward el in newRewards)
            {
                _userDAO.AddRewardToUser(user, el);
            }
        }

        public IList<User> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }
    }
}
