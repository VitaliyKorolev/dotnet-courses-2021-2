using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Interfaces;

namespace BLL
{
    public class RewardManager:IRewardBL
    {
        private readonly IRewardDAO _rewardDAO;
        private readonly IUserDAO _userDAO;

        public RewardManager(IRewardDAO rewardDAO, IUserDAO userDAO)
        {
            _rewardDAO = rewardDAO;
            _userDAO = userDAO;
        }
        public void DeleteReward(Reward reward)
        {
            _rewardDAO.DeleteReward(reward);

            foreach (var user in _userDAO.GetAllUsers())
            {
                user.Rewards.Remove(reward);
            }
        }
        public void AddReward(Reward reward)
        {
            _rewardDAO.AddReward(reward);
        }
       
        public IList<Reward> GetAllRewards()
        {
            return _rewardDAO.GetAllRewards();
        }
    }
}
