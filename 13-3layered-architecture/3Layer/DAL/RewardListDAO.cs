using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;



namespace DAL
{
    public class RewardListDAO:IRewardDAO
    {
        private readonly IUserDAO userDAO ;
        
        private List<Reward> _rewards = new List<Reward>() 
        {
            new Reward("Nobel premy", "Physics"),
            new Reward("Darvin premy", "Biology")

        };

        public RewardListDAO(UserListDAO userListDAO)
        {
            userDAO = userListDAO;
        }

        public void DeleteReward(Reward reward)
        {
            foreach(User u in userDAO.GetAllUsers())
            {
                u.Rewards.Remove(reward);
            }
            _rewards.Remove(reward);
        }
        public void AddReward(Reward reward)
        {
            _rewards.Add(reward);
        }

        public IList<Reward> GetAllRewards()
        {
            return _rewards.ToArray();
        }

        public void EditReward(Reward reward, string newTitle, string newDescriprion)
        {
            reward.Title = newTitle;
            reward.Description = newDescriprion;
        }
    }
}
