using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserBL
    {
        public IList<User> GetAllUsers();

        public void AddUser(User user);

        public void DeleteUser(User user);

        public void EditUser(User user, string newName, string newLastName, DateTime newBirthDay, List<Reward> newRewards);


    }
}
