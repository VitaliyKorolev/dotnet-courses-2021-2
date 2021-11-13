using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace DAL
{
    public class RewardListDAO:IRewardDAO
    {
        private readonly List<Reward> _rewards = new List<Reward>() 
        {
            new Reward("Nobel premy", "Physics"),
            new Reward("Darvin premy", "Biology")

        };

        public void DeleteReward(Reward reward)
        {
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
    }
}
