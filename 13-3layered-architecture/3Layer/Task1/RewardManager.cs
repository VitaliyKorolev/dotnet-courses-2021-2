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

        public RewardManager(IRewardDAO rewardDAO)
        {
            _rewardDAO = rewardDAO;
            
        }

        public void AddReward(Reward reward)
        {
            _rewardDAO.AddReward(reward);
        }

        public void DeleteReward(Reward reward)
        {
            _rewardDAO.DeleteReward(reward);
        }

        public void EditReward(Reward reward, string newTitle, string newDescriprion)
        {
            _rewardDAO.EditReward(reward, newTitle, newDescriprion);
        }

        public IList<Reward> GetAllRewards()
        {
            return _rewardDAO.GetAllRewards();
        }
    }
}
