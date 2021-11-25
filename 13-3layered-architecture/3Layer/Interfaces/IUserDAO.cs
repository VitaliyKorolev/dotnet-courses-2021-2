using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IUserDAO
    {
        public IList<User> GetAllUsers();

        public void AddUser(User user);

        public void DeleteUser(User user);

        public void EditUser(User user, string newName, string newLastName, DateTime newBirthDay);

        public void AddRewardToUser(User user, Reward reward);

        public void DeleteRewardsOfUser(User user);
        

    }
}
