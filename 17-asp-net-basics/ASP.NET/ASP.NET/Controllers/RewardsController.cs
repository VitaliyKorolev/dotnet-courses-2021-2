using BLL;
using DAL.DB;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    public class RewardsController : Controller
    {
        private readonly IRewardBL _rewardBL;

        public RewardsController(IRewardBL rewardBL)
        {

           // _rewardBL = new RewardManager(new RewardDBDAO());
           _rewardBL = rewardBL;
        }

        public IActionResult Index()
        {
            var rewards = _rewardBL.GetAllRewards();
            return View(rewards);
        }

        [HttpPost]
        public IActionResult Delete( Reward r)
        {
            _rewardBL.DeleteReward(r);  
            return RedirectToAction("Index", "Rewards");
        }

        [HttpGet]
        public IActionResult Edit(Reward r)
        {
            return View(r);
        }

        [HttpPost]
        public IActionResult Edit(Reward r, string newTitle, string newDescription )
        {
            if (newDescription == null) { newDescription = string.Empty; }
            _rewardBL.EditReward(r,newTitle, newDescription);

            return RedirectToAction("Index", "Rewards");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string newTitle, string newDescription)
        {
            if (newDescription == null) { newDescription = string.Empty; }
            Reward r = new Reward(newTitle, newDescription);
            _rewardBL.AddReward(r);
            return RedirectToAction("Index", "Rewards");
        }
    }
}
