using Entities;
using System;
using System.Collections.Generic;
using Interfaces;

namespace DAL
{
    public class UserListDAO:IUserDAO
    {
        private List<User> _users = new List<User>() 
        {
            new User(DateTime.Today.AddYears(-20), "Alex", "Smith"),
            new User(DateTime.Today.AddYears(-18), "Mihael", "Jhordan"),
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

        public void EditUser(User user, string newName, string newLastName, DateTime newBirthDay)
        {
            user.Name=newName;
            user.LastName = newLastName;
            user.BirthDate = newBirthDay;
        }

        public void AddRewardToUser(User user, Reward reward)
        {
            if (!user.Rewards.Contains(reward)) { user.Rewards.Add(reward); }
            
        }

        public void DeleteRewardsOfUser(User user)
        {
            user.Rewards.Clear();
        }
    }
}
