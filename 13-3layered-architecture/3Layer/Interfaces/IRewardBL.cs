using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRewardBL
    {
        public void DeleteReward(Reward reward);
        public void AddReward(Reward reward);
        public IList<Reward> GetAllRewards();
        
    }
}
