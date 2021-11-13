﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRewardDAO
    {
        public void DeleteReward(Reward reward);
        public void AddReward(Reward reward);
        public IList<Reward> GetAllRewards();
        
    }
}
